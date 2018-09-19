using ContosoUniversity.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.API.Data
{
    public class DbInitializer
    {
        public static void Initialize(ContosoUniversityAPIContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }

            var noticias = new Noticia[]
            {
                new Noticia {
                    Title = "STJD rejeita pedido do Palmeiras para impugnar final do Paulistão e mantém Corinthians campeão",
                    Texto = System.Net.WebUtility.HtmlEncode("<p>O STJD (Superior Tribunal de Justiça Desportiva) rejeitou, na manhã desta quarta-feira, o pedido do Palmeiras para impugnar a decisão do Campeonato Paulista. Os auditores entenderam que o clube não conseguiu apresentar provas que sustentassem o argumento de interferência externa na partida. A decisão foi unânime. Com isso, o Corinthians está mantido como campeão paulista de 2018.</p><p>A defesa do Palmeiras, presente no julgamento, disse que os próximos passos serão decididos em conversa com o presidente do clube, Maurício Galiotte. Não cabem mais recursos em tribunais regionais e nacionais.A diretoria analisa se levará o caso à CAS(Corte Arbitral do Esporte), a última instância do direito esportivo.</p><p>O Palmeiras argumentava que houve interferência externa na decisão da arbitragem de desmarcar um pênalti assinalado a favor do Palmeiras (de Ralf em Dudu) na decisão do dia 8 de abril (veja toda a confusão em vídeo abaixo). O Corinthians venceu o jogo por 1 a 0 e conquistou o título nos pênaltis.</p>") },
                new Noticia {
                    Title = "Neymar interrompe entrevista após jogo entre Liverpool e PSG para parabenizar Firmino",
                    Texto = System.Net.WebUtility.HtmlEncode("<p>Depois de entrar no segundo tempo e brilhar ao marcar nos acréscimos o gol que deu a vitória ao Liverpool sobre o PSG por 3 a 2, na Liga dos Campeões, Firmino teve o reconhecimento não somente da torcida e da opinião pública, mas também do adversário. Estrela da equipe parisiense e companheiro de seleção brasileira, Neymar fez questão de parabenizar o atacante dos Reds pela atuação.</p><p>Goleiro do Liverpool exalta Firmino: Em terra de cego, quem tem um olho é rei.</p><p>O camisa 10 do PSG cumprimentou Firmino com um abraço e algumas palavras enquanto o jogador do Liverpool concedia entrevista na zona mista, após a partida.Requisitado pelos jornalistas, Neymar, no entanto, preferiu não conversar com os veículos de imprensa e saiu depois de encontrar o camisa 9 do Liverpool.</p><p>Neymar to Firmino:Congratulations, you played great</p><p>Depois de entrar no segundo tempo, Firmino salvou a pele do Liverpool.O camisa 9 marcou o gol que deu a vitória aos Reds, já nos acréscimos, aos 46 da etapa final.Assim, os Reds saíram vitoriosos em sua estreia na Liga dos Campeões.</p>") },
                new Noticia {
                    Title = "Campeã olímpica, Rafaela Silva se reinventa para voltar ao pódio de um Mundial em Baku",
                    Texto = System.Net.WebUtility.HtmlEncode("<p>Rafaela Silva brinca no treino da seleção brasileira. É só sorrisos. Afinal está de volta ao seu ambiente natural. Depois de um 2017 atípico, repleto de compromissos com patrocinadores, a campeã olímpica volta a se dedicar mais aos tatames. A judoca está se reinventando por uma meta: retornar ao pódio de um Mundial. E já pode ser no sábado, em Baku, no Azerbaijão. O SporTV 2 transmite as finais do Mundial de Judô a partir desta quinta-feira, às 9h (de Brasília). Gabriela Chibana (48kg) e Phelipe Pelim e Eric Takabatake (60kg) são os primeiros brasileiros na disputa.</p><p>- Eu estou muito focada nesse Campeonato Mundial. A última medalha que eu ganhei em já fez cinco anos. Então acho que um dos meus objetivos nesse ciclo é voltar ao pódio em um Mundial, uma competição importante - disse a judoca.</p><p>Atual campeã olímpica no peso leve (-57kg), Rafaela até foi ao pódio no Mundial de 2017, só que na disputa por equipes mistas - o Brasil ficou com a prata. Ela ainda tem no currículo o ouro do Mundial de 2013 e a prata de 2011 na sua categoria, além de uma prata por equipes femininas de 2013. No ano passado, porém, foi eliminada na primeira luta.</p>") },
                new Noticia {
                    Title = "Ex-dirigentes de MLS e Concacaf são banidos do futebol por Comitê de Ética da Fifa",
                    Texto = System.Net.WebUtility.HtmlEncode("<p>O Comitê de Ética da Fifa anunciou, nesta quarta, o banimento total do futebol de três dirigentes: Aaron Davidson, ex-presidente do conselho de administração da MLS e presidente da Traffic Sports EUA, Costas Takkas, ex-funcionário da Concacaf, e Miguel Trujillo, ex-agente da entidade máxima do futebol e dono de empresas de consultoria esportiva. Todos foram condenados por suborno e corrupção e estão fora de qualquer atividade relacionada ao futebol.</p><p>As investigações foram iniciadas através de comunicados de imprensa do Departamento de Justiça dos Estados Unidos. Aaron Davidson se declarou culpado das acusações de extorsão e fraude eletrônica, por conta de esquemas de suborno em troca de obtenção de contratos para mídia e direitos de marketing em competições futebolísticas.</p><p>Costas Takkas, por sua vez, se declarou culpado em esquemas de recebimento de pagamento de suborno em nome do ex-presidente da Concacaf, Jeffrey Webb, em troca de concessão dos mesmos tipos de contratos. Miguel Trujillo também confessou envolvimento com suborno de oficiais do futebol. Ambos foram condenados por conspiração e lavagem de dinheiro.</p><p>Além disso, uma multa de 1 milhão de francos suíços (R$ 4,27 milhões) foi imposta a cada um dos três. As proibições entram em vigor após os mesmos serem notificados da decisão.</p>") }
            };

            foreach (Noticia n in noticias)
            {
                context.Noticia.Add(n);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstName = "Kim", LastName = "Abercrombie", HireDate = DateTime.Parse("11/03/1995") },
                new Instructor { FirstName = "Fadi", LastName = "Fakhouri", HireDate = DateTime.Parse("06/07/2002") },
                new Instructor { FirstName = "Roger", LastName = "Harui", HireDate = DateTime.Parse("01/07/1998") },
                new Instructor { FirstName = "Candace", LastName = "Kapoor", HireDate = DateTime.Parse("01/07/1998") },
                new Instructor { FirstName = "Roger", LastName = "Zheng", HireDate = DateTime.Parse("12/02/2004") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "English", Budget = 350000, StartDate = DateTime.Parse("01/09/2007"), Instructor  = instructors.Single( i => i.LastName == "Abercrombie") },
                new Department { Name = "Mathematics", Budget = 100000, StartDate = DateTime.Parse("01/09/2007"), Instructor  = instructors.Single( i => i.LastName == "Fakhouri") },
                new Department { Name = "Engineering", Budget = 350000, StartDate = DateTime.Parse("01/09/2007"), Instructor  = instructors.Single( i => i.LastName == "Harui") },
                new Department { Name = "Economics", Budget = 100000, StartDate = DateTime.Parse("01/09/2007"), Instructor  = instructors.Single( i => i.LastName == "Kapoor") }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();


            var courses = new Course[]
            {
                new Course {Title = "Chemistry",  Credits = 3, Department = departments.Single( s => s.Name == "Engineering") },
                new Course {Title = "Microeconomics", Credits = 3, Department = departments.Single( s => s.Name == "Economics") },
                new Course {Title = "Calculus", Credits = 4, Department = departments.Single( s => s.Name == "Mathematics") },
                new Course {Title = "Trigonometry", Credits = 4, Department = departments.Single( s => s.Name == "Mathematics") },
                new Course {Title = "Composition", Credits = 3, Department = departments.Single( s => s.Name == "English") },
                new Course {Title = "Literature", Credits = 4, Department = departments.Single( s => s.Name == "English") },
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();


            var students = new Student[]
            {
                new Student { FirstName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("01/09/2010")},
                new Student { FirstName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("01/09/2012") },
                new Student { FirstName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("01/09/2013") },
                new Student { FirstName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("01/09/2012") },
                new Student { FirstName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("01/09/2012") },
                new Student { FirstName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("01/09/2011") },
                new Student { FirstName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("01/09/2013") },
                new Student { FirstName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("01/09/2005") }
            };

            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var studentCourse = new StudentCourse[]
            {
                new StudentCourse {
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).ID
                },
                new StudentCourse {
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).ID
                },
                new StudentCourse {
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).ID
                },
                new StudentCourse {
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).ID
                },
                new StudentCourse {
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).ID
                },
                new StudentCourse {
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).ID
                },
                new StudentCourse {
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").ID
                },
                new StudentCourse {
                    StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").ID
                },
                new StudentCourse {
                    StudentID = students.Single(s => s.LastName == "Li").ID,
                    CourseID = courses.Single(c => c.Title == "Composition").ID
                },
                new StudentCourse {
                    StudentID = students.Single(s => s.LastName == "Justice").ID,
                    CourseID = courses.Single(c => c.Title == "Literature").ID
                }
            };


            foreach (StudentCourse e in studentCourse)
            {
                var enrollmentInDataBase = context.StudentCourse.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.ID == e.CourseID).SingleOrDefault();

                if (enrollmentInDataBase == null)
                {
                    context.StudentCourse.Add(e);
                }
            }

            context.SaveChanges();
        }

    }
}