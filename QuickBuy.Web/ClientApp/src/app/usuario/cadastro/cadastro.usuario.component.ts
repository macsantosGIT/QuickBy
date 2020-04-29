import { Component, OnInit } from "@angular/core";
import { Usuario } from "../../modelo/usuario";
import { Router, ActivatedRoute } from "@angular/router";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";

@Component({
  selector: "cadastro-usuario",
  templateUrl: "./cadastro.usuario.component.html",
  styleUrls: ["./cadastro.usuario.component.css"]
})
export class CadastroUsuarioComponent implements OnInit {
  public usuario: Usuario;
  public ativa_spinner: boolean;
  public mensagem: string;
  public usuarioCadastrado: boolean;

  constructor(private usuarioServico: UsuarioServico) {
  }

  ngOnInit(): void {
    this.usuario = new Usuario();
  }

  cadastrar() {
    this.ativa_spinner = true;
    this.usuarioServico.cadastrarUsuario(this.usuario)
      .subscribe(
        usuarioJson => {
          this.usuarioCadastrado = true;
          this.mensagem = "";
          this.ativa_spinner = false;
        },
        e => {
          this.ativa_spinner = false;
          this.mensagem = e.error;
        }
      );
  }

}
