import { Component, OnInit } from "@angular/core";
import { templateJitUrl } from "@angular/compiler/src/compile_metadata";
import { Produto } from "../../modelo/produto";
import { ProdutoServico } from "../../servicos/produto/produto.servico";
import { Router } from "@angular/router";

@Component({
  selector: "pesquisa-produto",
  templateUrl: "./pesquisa.produto.component.html",
  styleUrls: ["pesquisa.produto.component.css"]
})
export class PesquisaProdutoComponent implements OnInit {

  public produtos: Produto[];

  ngOnInit(): void {

  }

  constructor(private produtoServico: ProdutoServico, private router: Router) {
    this.produtoServico.obterTodosProdutos()
      .subscribe(
        produtos => {
          this.produtos = produtos
        },
      e => {

      });
  }

  public adicionarProduto() {
    sessionStorage.setItem('produtoSession', "");
    this.router.navigate(['/produto']); 
  }

  public excluirProduto(produto: Produto) {
    var retorno = confirm("Deseja excluir o produto?")
    if (retorno == true) {
      this.produtoServico.deletar(produto).subscribe(
        produtos => {
          this.produtos = produtos;
        },
        e => {
        }
      );
    }
  }

  public editarProduto(produto: Produto) {
    sessionStorage.setItem('produtoSession', JSON.stringify(produto));
    this.router.navigate(['/produto']);
  }
}
