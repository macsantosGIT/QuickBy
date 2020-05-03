import { Component, OnInit } from '@angular/core';
import { ProdutoServico } from '../../servicos/produto/produto.servico';
import { Produto } from '../../modelo/produto';
import { Router } from '@angular/router';
import { LojaCarrinhoCompra } from '../carrinho/loja.carrinho.compras';

@Component({
  selector: "loja-app-produto",
  templateUrl: "./loja.produto.component.html",
  styleUrls: ["./loja.produto.component.css"]
})
export class LojaProdutoComponent implements OnInit{
  public produto: Produto;
  public carrinhaCompra: LojaCarrinhoCompra;

  ngOnInit(): void {
    this.carrinhaCompra = new LojaCarrinhoCompra();
    var produtoDetalhe = sessionStorage.getItem('produtoDetalhe');
    if (produtoDetalhe) {
      this.produto = JSON.parse(produtoDetalhe);
    }
  }

  constructor(private produtoServico: ProdutoServico, private router: Router) {

  }

  public comprar() {
    this.carrinhaCompra.adicionar(this.produto);
    this.router.navigate(['/loja-efetivar']);
  }

}
