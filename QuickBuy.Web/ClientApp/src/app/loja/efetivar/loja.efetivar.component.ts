import { Component, OnInit } from "@angular/core";
import { Produto } from "../../modelo/produto";
import { LojaCarrinhoCompra } from "../carrinho/loja.carrinho.compras";
import { Pedido } from "../../modelo/pedido";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";
import { ItemPedido } from "../../modelo/itemPedido";
import { PedidoServico } from "../../servicos/pedido/pedido.servico";
import { Router } from "@angular/router";

@Component({
  selector: "loja-efetivar",
  templateUrl: "./loja.efetivar.component.html",
  styleUrls: ["./loja.efetivar.component.css"]
})
export class LojaEfetivarComponent implements OnInit {
  public produtos: Produto[];
  public carrinhoCompra: LojaCarrinhoCompra;
  public total: number;

  ngOnInit(): void {
    this.carrinhoCompra = new LojaCarrinhoCompra();
    this.produtos = this.carrinhoCompra.obterProdutos();
    this.atualizarTotal();
  }

  constructor(private usuarioServico: UsuarioServico, private pedidoServico: PedidoServico, private router: Router) {

  }

  public atualizarPreco(produto: Produto, quantidade: number) {
    if (!produto.precoOriginal) {
      produto.precoOriginal = produto.preco;
    }
    if (quantidade <= 0) {
      quantidade = 1;
      produto.quantidade = quantidade;
    } 
    produto.preco = produto.precoOriginal * quantidade;
    this.carrinhoCompra.atulizar(this.produtos);
    this.atualizarTotal();
  }

  public remover(produto: Produto) {
    this.carrinhoCompra.removerProduto(produto);
    this.produtos = this.carrinhoCompra.obterProdutos();
    this.atualizarTotal();
  }

  public atualizarTotal() {
    this.total = this.produtos.reduce((acc, produto) => acc + produto.preco, 0);
  }

  public efetivarCompra() {
    this.pedidoServico.efetivarCompra(this.criarPedido())
      .subscribe(
        pedidoId => {
          sessionStorage.setItem("pedidoId", pedidoId.toString());
          this.produtos = [];
          this.carrinhoCompra.limparCarrinhoCompras();
          this.router.navigate(["/compra-realizada-sucesso"]);
        }, e => {

        }
      );
    
  }

  public criarPedido(): Pedido {
    let pedido = new Pedido();
    pedido.usuarioId = this.usuarioServico.usuario.id;
    pedido.cep = "02614000";
    pedido.cidade = "São Paulo";
    pedido.estado = "SP";
    pedido.dataPrevisaoEntrega = new Date();
    pedido.formaPagamentoId = 1;
    pedido.numeroEndereco = "12";
    pedido.enderecoCompleto = "Rua dos Arvoredos";
    this.produtos = this.carrinhoCompra.obterProdutos();
    for (let produto of this.produtos) {
      let itemPedido = new ItemPedido();
      itemPedido.produtoId = produto.id;
      if (!produto.quantidade)
        produto.quantidade = 1;
      itemPedido.quantidade = produto.quantidade;
      pedido.itens.push(itemPedido);
    }

    return pedido;
  }
}
