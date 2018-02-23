using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaratonaBot.Modulo3.Formulario
{
    [Serializable]
    [Template(TemplateUsage.NotUnderstood,"Desculpe não entendi \"{0}\".")]
    public class Pedido
    {
        public Salgadinhos Salgadinhos { get; set; }
        public Bebidas Bebidas { get; set; }
        public TipoEntrega TipoEntrega { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public static IForm<Pedido> BuildForm()
        {
            var form = new FormBuilder<Pedido>();
            form.Configuration.DefaultPrompt.ChoiceStyle = ChoiceStyleOptions.Buttons;
            form.Configuration.Yes = new string[] { "Sim","yep","si","Vai logo" };
            form.Message("Olá, seja bem vindo. Será um prazer atender você.");
            form.OnCompletion(async (context, pedido) => {
                //Salvar 
                //Consultar APi
                // 
                await context.PostAsync("Seu pedido número 1321213 foi gerado.");
            } );
            return form.Build();
        }
    }

    [Describe("tipo de entrega")]
    public enum TipoEntrega
    {
        [Describe("Retirar no Local")]
        RetirarNoLocal = 1,
        [Describe("Motoboy")]
        Motoboy
    }

    [Describe("salgado")]
    public enum Salgadinhos
    {
        [Terms("Esfirra", "Esfira", "isfira", "e")]
        Esfirra = 1,
        [Terms("quibe", "kibe", "q", "k","Quibe")]
        Quibe,
        [Terms("Coxina", "Coxinha", "c", "Coxa", "cochinha")]
        Coxinha
    }

    [Describe("bebida")]
    public enum Bebidas
    {
        [Terms("Água","agua","h2o","a")]
        [Describe("Água")]
        Agua = 1,

        [Terms("Refrigerante", "refrigerante", "refri", "r")]
        [Describe("Refrigerante")]
        Refrigerante,
        [Terms("Suco", "suco", "natural", "s")]
        [Describe("Suco")]
        Suco
    }
}