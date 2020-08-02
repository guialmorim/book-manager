using book_manager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace book_manager.DataAccess
{
    public class BooksInit : CreateDatabaseIfNotExists<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            List<Gender> Genders = new List<Gender>()
            {
                new Gender() { Name = "Administração" },
                new Gender() { Name = "Agropecuária" },
                new Gender() { Name = "Artes" },
                new Gender() { Name = "Autoajuda" },
                new Gender() { Name = "Ciências Biológicas" },
                new Gender() { Name = "Ciências Exatas" },
                new Gender() { Name = "Ciências Humanas e Sociais" },
                new Gender() { Name = "Cursos e Idiomas" },
                new Gender() { Name = "Didáticos" },
                new Gender() { Name = "Direito" },
                new Gender() { Name = "Economia" },
                new Gender() { Name = "Engenharia e Tecnologia" },
                new Gender() { Name = "Gastronomia" },
                new Gender() { Name = "Geografia e Historia" },
                new Gender() { Name = "Informática" },
                new Gender() { Name = "Linguística" },
                new Gender() { Name = "Literatura Nacional" },
                new Gender() { Name = "Medicina" },
                new Gender() { Name = "Religião" },
                new Gender() { Name = "Turismo" },
            };

            Genders.ForEach(gender => context.Genders.Add(gender));

            List<Book> Books = new List<Book>()
            {
                new Book() {
                            Title = "O Poder do Hábito - Por Que Fazemos o Que Fazemos na Vida e Nos Negócios",
                            Author = "Duhigg, Charles",
                            YearEdition = 2012,
                            Value = 40.00m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Administração")
                },
                new Book() {
                            Title = "Os Segredos da Mente Milionária - Aprenda a Enriquecer Mudando seus Conceitos Sobre o Dinheiro",
                            Author = "Eker, T. Harv",
                            YearEdition = 1992,
                            Value = 22.40m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Administração")
                },
                new Book() {
                            Title = "Adestramento Inteligente",
                            Author = "Rossi, Alexandre",
                            YearEdition = 2015,
                            Value = 20.80m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Agropecuária")
                },
                new Book() {
                            Title = "Aves Florestais do Brasil",
                            Author = "Bini, Etson",
                            YearEdition = 2014,
                            Value = 89.90m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Agropecuária")
                },
                new Book() {
                            Title = "Guerra Civil",
                            Author = "McNiven, Steve; MILLAR, MARK",
                            YearEdition = 2010,
                            Value = 48m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Artes")
                },
                new Book() {
                            Title = "Batman - A Morte da Família",
                            Author = "Capullo, Greg; Snyder, Scott",
                            YearEdition = 2016,
                            Value = 60.80m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Artes")
                },
                new Book() {
                            Title = "Manual de Sobrevivência do Adolescente",
                            Author = "Loures, Camila",
                            YearEdition = 2016,
                            Value = 19.90m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Autoajuda")
                },
                new Book() {
                            Title = "O Mapa da Felicidade - As Coordenadas Para Curar A Sua Vida e Nunca Mais Olhar Para Trás",
                            Author = "Capelas, Heloísa",
                            YearEdition = 2014,
                            Value = 23.90m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Autoajuda")
                },
                new Book() {
                            Title = "A Origem Das Espécies - Edição Ilustrada",
                            Author = "Darwin, Charles",
                            YearEdition = 2014,
                            Value = 71.90m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Ciências Biológicas")
                },
                new Book() {
                            Title = "A Sexta Extinção - Uma História Não Natural",
                            Author = "Kolbert, Elizabeth",
                            YearEdition = 2015,
                            Value = 17.00m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Ciências Biológicas")
                },
                new Book() {
                            Title = "Raciocínio Lógico Facilitado",
                            Author = "Villar, Bruno",
                            YearEdition = 2016,
                            Value = 134.10m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Ciências Exatas")
                },
                new Book() {
                            Title = "Cálculo",
                            Author = "Stewart, James",
                            YearEdition = 2015,
                            Value = 143.20m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Ciências Exatas")
                },
                new Book() {
                            Title = "Uma Breve História da Humanidad",
                            Author = "Harari, Yuval Noah",
                            YearEdition = 2015,
                            Value = 47.90m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Ciências Humanas e Sociais")
                },
                new Book() {
                            Title = "O Príncipe - Obra Completa",
                            Author = "Maquiavel, Nicolau",
                            YearEdition = 2007,
                            Value = 17.10m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Ciências Humanas e Sociais")
                },
                new Book() {
                            Title = "English Grammar In Use With Answers",
                            Author = "Murphy, Raymond",
                            YearEdition = 2012,
                            Value = 173.50m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Cursos e Idiomas")
                },
                new Book() {
                            Title = "Gramática Y Práctica de Español",
                            Author = "Fanjul, AdrIan",
                            YearEdition = 2014,
                            Value = 82.00m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Cursos e Idiomas")
                },
                new Book() {
                            Title = "Novíssima Gramática da Língua Portuguesa",
                            Author = "Cegalla, Domingos Paschoal",
                            YearEdition = 2009,
                            Value = 82.00m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Didáticos")
                },
                new Book() {
                            Title = "Química - Vol. Único",
                            Author = "Usberco, Joao; Salvador, Edgard",
                            YearEdition = 2013,
                            Value = 194.00m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Didáticos")
                },
                new Book() {
                            Title = "Direito Processual Civil Esquematizado",
                            Author = "Gonçalves, Marcus Vinicius Rios; (Coord.), Pedro Lenza",
                            YearEdition = 2016,
                            Value = 163.20m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Direito")
                },
                new Book() {
                            Title = "Direito Administrativo",
                            Author = "Pietro, Maria Sylvia Zanella Di",
                            YearEdition = 2016,
                            Value = 108.10m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Direito")
                },
                new Book() {
                            Title = "O Capital - No Século XXI",
                            Author = "Piketty, Thomas",
                            YearEdition = 2014,
                            Value = 34.20m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Economia")
                },
                new Book() {
                            Title = "Fundamentos de Economia",
                            Author = "Vasconcellos, Marco Antonio S.; Garcia, Manuel E.",
                            YearEdition = 2014,
                            Value = 68.10m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Economia")
                },
                new Book() {
                            Title = "Manual Do Mundo",
                            Author = "Alfredo Luis Mateus; Ibere Thenorio",
                            YearEdition = 2014,
                            Value = 39.70m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Engenharia e Tecnologia")
                },
                new Book() {
                            Title = "Ciência Engenharia de Materiais -Uma Introdução",
                            Author = "Callister Jr., William D.",
                            YearEdition = 2012,
                            Value = 223.80m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Engenharia e Tecnologia")
                },
                new Book() {
                            Title = "Bela Cozinha - As Receitas",
                            Author = "Gil , Bela",
                            YearEdition = 2014,
                            Value = 29.10m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Gastronomia")
                },
                new Book() {
                            Title = "Por Uma Vida Mais Doce",
                            Author = "Noce, Danielle",
                            YearEdition = 2014,
                            Value = 79.80m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Gastronomia")
                },
                new Book() {
                            Title = "1808",
                            Author = "Gomes, Laurentino",
                            YearEdition = 2014,
                            Value = 31.90m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Geografia e Historia")
                },
                new Book() {
                            Title = "A História do Mundo Para Quem Tem Pressa -Mais de 5000 Anos de História Resumidos Em 200 Páginas",
                            Author = "Marriot, Emma",
                            YearEdition = 2015,
                            Value = 22.60m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Geografia e Historia")
                },
                new Book() {
                            Title = "Redes de Computadores",
                            Author = "Tanenbaum, Andrew S.; J.Wetherall, David",
                            YearEdition = 2011,
                            Value = 166.40m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Informática")
                },
                new Book() {
                            Title = "Lógica de Programação - Conhecendo Algoritmos e Criando Programas",
                            Author = "Simão , Daniel Hayashida; Reis , Wellington José Dos",
                            YearEdition = 2015,
                            Value = 26.40m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Informática")
                },
                new Book() {
                            Title = "Mídia Training - Como Usar A Mídia A Seu Favor",
                            Author = "Barbeiro, Herodoto",
                            YearEdition = 2015,
                            Value = 25.30m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Linguística")
                },
                new Book() {
                            Title = "Anatomia de Um Julgamento - Ifigênia Em Forest Hills",
                            Author = "Malcolm, Janet",
                            YearEdition = 2012,
                            Value = 22.40m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Linguística")
                },
                new Book() {
                            Title = "Tratado de Medicina Interna Veterinária - Doenças do Cão e do Gato",
                            Author = "Ettinger, Stephen J.; Feldman, Edward C.",
                            YearEdition = 2004,
                            Value = 1309.50m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Medicina")
                },
                new Book() {
                            Title = "Clínica Veterinária - Um Tratado de Doenças dos Bovinos, Ovinos, Suínos, Caprinos e Equinos",
                            Author = "Outros; Blood, Douglas C.; Radostits, Otto M.",
                            YearEdition = 2002,
                            Value = 1080.00m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Medicina")
                },
                new Book() {
                            Title = "Quarto de Guerra - A Oração É Uma Arma Poderosa na Batalha Espiritual",
                            Author = "Fabry, Chris",
                            YearEdition = 2015,
                            Value = 25.50m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Religião")
                },
                new Book() {
                            Title = "Cristianismo Puro e Simples",
                            Author = "Lewis, C. S.",
                            YearEdition = 2009,
                            Value = 36.00m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Religião")
                },
                new Book() {
                            Title = "Não Conta Lá Em Casa",
                            Author = "Fran, André",
                            YearEdition = 2013,
                            Value = 56.60m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Turismo")
                },
                new Book() {
                            Title = "O Melhor Guia de Nova York",
                            Author = "Andrade, Pedro",
                            YearEdition = 2013,
                            Value = 29.30m,
                            Gender = Genders.FirstOrDefault(g => g.Name == "Turismo")
                }
            };

            Books.ForEach(books => context.Books.Add(books));

            context.SaveChanges();
        }
    }
}