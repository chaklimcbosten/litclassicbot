using litclassicbot.Classes;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace litclassicbot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // проверка на то, какое именно клиент-приложение
            // больше 12 символов - skype
            if (activity.Conversation.Id.Count() > 12)
            {
                // проверка на то, был ли хотя бы один запрос от этого клиента
            }
            // это telegram
            else
            {

            }

            if (activity.Text == "/start")
            {
                try
                {
                    string start = "**Приветствую!**\n\r" +
                        "Команды боту можно отправлять, вводя их с помощью клавиатуры в поле ввода диалога, либо нажав на клавишу со значком \"/\" в поле ввода, " +
                        "а затем по нужной команде во всплывшем списке доступных команд.\n\r" +
                        "Для ознакомления предлагаю две основные команды бота, вызвать которые можно нажав по ним в данном сообщении:\n\r" +
                        "/newpartical - бот пришлёт случайно выбранную частицу из всех имеющихся в его базе;\n\r" +
                        "/newpoempartical - бот пришлёт случайно выбранную частицу из всех имеющихся стихотворных частиц в его базе.\n\r\n\r" +
                        "**Приятного и полезного пользования!**";

                    await context.PostAsync(start);
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода команды /start...");
                }
            }
            else if ((activity.Text == "/newpoempartical") || (activity.Text.ToLower().Contains("стих")) | (activity.Text.ToLower().Contains("стиш")))
            {
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    List<string> listGetRandomParticle = new List<string>();
                    listGetRandomParticle = currentConnection.GetRandomPoemParticle(activity.Conversation.Id);
                    string particle = listGetRandomParticle[0];
                    particle = particle.Replace("$$strong-open$$", "**");
                    particle = particle.Replace("$$emphasis-open$$", "*");
                    particle = particle.Replace("$$strong-close$$", "**");
                    particle = particle.Replace("$$emphasis-close$$", "*");
                    string title = listGetRandomParticle[1];
                    int indeLastLine = Convert.ToInt32(listGetRandomParticle[2]);
                    int bookID = Convert.ToInt32(listGetRandomParticle[4]);
                    var card = new HeroCard("Дальнейшие возможные действия:");
                    card.Buttons = new List<CardAction>()
        {
                new CardAction()
                {
                    Title = "Сообщить об ошибке.",
                    Type = ActionTypes.PostBack,
                    Value = "reportPartical"
                },
                new CardAction()
                {
                    Title = "Добавить в \"избранное\".",
                    Type = ActionTypes.PostBack,
                    Value = "addParticalToFavourites"
                },
                new CardAction()
                {
                    Title = "Скачать книгу.",
                    Type = ActionTypes.PostBack,
                    Value = "download " + bookID
                },
                new CardAction()
                {
                    Title = "Ещё \"частица\".",
                    Type = ActionTypes.PostBack,
                    //Value = "readNext " + indeLastLine + " " + bookID
                    Value = "/newpoempartical"
                }
        };

                    var reply = activity.CreateReply("");
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment()
                    {
                        ContentType = HeroCard.ContentType,
                        Content = card
                    });

                    await context.PostAsync(particle);
                    await context.PostAsync("Сведения о частице:\n\r" + title);
                    await context.PostAsync(reply);
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода команды /newpoempartical...");
                }
            }
            else if ((activity.Text == "/newpartical") || (activity.Text.ToLower().Contains("частиц")))
            {
                //context.Forward()                             
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    List<string> listGetRandomParticle = new List<string>();
                    listGetRandomParticle = currentConnection.GetRandomParticle(activity.Conversation.Id);
                    string particle = listGetRandomParticle[0];
                    particle = particle.Replace("$$strong-open$$", "**");
                    particle = particle.Replace("$$emphasis-open$$", "*");
                    particle = particle.Replace("$$strong-close$$", "**");
                    particle = particle.Replace("$$emphasis-close$$", "*");
                    string title = listGetRandomParticle[1];
                    int indeLastLine = Convert.ToInt32(listGetRandomParticle[2]);
                    int bookID = Convert.ToInt32(listGetRandomParticle[4]);
                    var card = new HeroCard("Дальнейшие возможные действия:");
                    card.Buttons = new List<CardAction>()
        {
                new CardAction()
                {
                    Title = "Сообщить об ошибке.",
                    Type = ActionTypes.PostBack,
                    Value = "reportPartical"
                },
                new CardAction()
                {
                    Title = "Добавить в \"избранное\".",
                    Type = ActionTypes.PostBack,
                    Value = "addParticalToFavourites"
                },
                new CardAction()
                {
                    Title = "Скачать книгу.",
                    Type = ActionTypes.PostBack,
                    Value = "download " + bookID
                },
                new CardAction()
                {
                    Title = "Ещё \"частица\".",
                    Type = ActionTypes.PostBack,
                    //Value = "readNext " + indeLastLine + " " + bookID
                    Value = "/newpartical"
                }
        };

                    var reply = activity.CreateReply("");
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment()
                    {
                        ContentType = HeroCard.ContentType,
                        Content = card
                    });

                    await context.PostAsync(particle);
                    await context.PostAsync("Сведения о частице:\n\r" + title);
                    await context.PostAsync(reply);

                    //reply.ChannelData = { "custom Telegram JSON"};
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода команды /newpartical...");
                }
            }
            else if ((activity.Text == "/newword") || (activity.Text.ToLower().Contains("слов")))
            {
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    List<List<string>> listListsGetRandomWord = new List<List<string>>();
                    listListsGetRandomWord = currentConnection.GetRandomWord(activity.Conversation.Id);
                    // получение имени слова
                    string wordName = listListsGetRandomWord[0][0];
                    // получение значения слова
                    string wordValue = listListsGetRandomWord[0][1];
                    // получение ссылок слова
                    //string wordLinks = listListsGetRandomWord[0][2];
                    // получение первой буквы слова
                    // может быть, проще её получать из имени?
                    //string wordFirstLetter = listListsGetRandomWord[0][3];
                    string wordMessage = "**" + wordName + "**\n\r" +
                        "*Значение слова:*\n\r" + wordValue;
                    string subWordsMessage = "";

                    if (listListsGetRandomWord.Count > 1)
                    {
                        foreach (List<string> listWord in listListsGetRandomWord)
                        {
                            string subWordName = listWord[0];
                            string subWordValue = listWord[1];
                            subWordsMessage += "**Упомянутые в ссылках слова.**\n\r*" + subWordName + "* - " + subWordValue + "\n\r"; 
                        }
                    }

                    var card = new HeroCard("Дальнейшие возможные действия:");
                    card.Buttons = new List<CardAction>()
        {
                new CardAction()
                {
                    Title = "Сообщить об ошибке.",
                    Type = ActionTypes.PostBack,
                    Value = "reportWord"
                },
                //new CardAction()
                //{
                //    Title = "Добавить в словарь.",
                //    Type = ActionTypes.PostBack,
                //    Value = "addWordToDictionary"
                //},
                new CardAction()
                {
                    Title = "Ещё слово.",
                    Type = ActionTypes.PostBack,
                    Value = "/newword"
                }
        };

                    var reply = activity.CreateReply("");
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment()
                    {
                        ContentType = HeroCard.ContentType,
                        Content = card
                    });

                    await context.PostAsync(wordMessage);
                    await context.PostAsync(subWordsMessage);
                    await context.PostAsync(reply);
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода команды /newword...");
                }
            }
            //        else if (activity.Text == "/newpartical")
            //        {                          
            //            try
            //            {
            //                BotDBConnect currentConnection = new BotDBConnect();

            //                currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

            //                List<string> listGetRandomPartical = new List<string>();
            //                listGetRandomPartical = currentConnection.GetRandomPartical(Convert.ToInt32(activity.Conversation.Id));
            //                string partical = listGetRandomPartical[1];
            //                string title = listGetRandomPartical[0];
            //                int indeLastLine = Convert.ToInt32(listGetRandomPartical[2]);
            //                int bookID = Convert.ToInt32(listGetRandomPartical[4]);

            //                var reply = activity.CreateReply("Сведения о частице:\n\r" + title);
            //                reply.Type = ActivityTypes.Message;
            //                reply.TextFormat = TextFormatTypes.Plain;

            //                reply.SuggestedActions = new SuggestedActions()
            //                {
            //                    Actions = new List<CardAction>()
            //{
            //    new CardAction(){ Title = "Сообщить об ошибке.", Type=ActionTypes.PostBack, Value="reportPartical" },
            //    new CardAction(){ Title = "Добавить в \"избранное\".", Type=ActionTypes.PostBack, Value="addParticalToFavourites" },
            //    new CardAction(){ Title = "Скачать книгу.", Type=ActionTypes.PostBack, Value="download " + bookID },
            //    new CardAction(){ Title = "Новая частица.", Type=ActionTypes.PostBack, Value="/newpartical" }
            //}
            //                };

            //                await context.PostAsync(partical);
            //                //await context.PostAsync("Сведения о частице:\n\r" + title);
            //                await context.PostAsync(reply);

            //                //reply.ChannelData = { "custom Telegram JSON"};
            //            }
            //            catch
            //            {
            //                await context.PostAsync("Какие-то неполадки с кодом в команде /newpartical...");
            //            }
            //        }
            else if (activity.Text == "/newnonartpartical")
            {
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    List<string> listGetRandomParticle = new List<string>();
                    listGetRandomParticle = currentConnection.GetRandomPoemParticle(activity.Conversation.Id);
                    string particle = listGetRandomParticle[1];
                    string title = listGetRandomParticle[0];
                    int indeLastLine = Convert.ToInt32(listGetRandomParticle[2]);
                    int bookID = Convert.ToInt32(listGetRandomParticle[4]);
                    var card = new HeroCard("Дальнейшие возможные действия:");
                    card.Buttons = new List<CardAction>()
        {
                new CardAction()
                {
                    Title = "Сообщить об ошибке.",
                    Type = ActionTypes.PostBack,
                    Value = "reportPartical"
                },
                new CardAction()
                {
                    Title = "Добавить в \"избранное\".",
                    Type = ActionTypes.PostBack,
                    Value = "addParticalToFavourites"
                },
                new CardAction()
                {
                    Title = "Скачать книгу.",
                    Type = ActionTypes.PostBack,
                    Value = "download " + bookID
                },
                new CardAction()
                {
                    Title = "Новая не художественная \"частица\".",
                    Type = ActionTypes.PostBack,
                    //Value = "readNext " + indeLastLine + " " + bookID
                    Value = "/newnonartpartical"
                }
        };

                    var reply = activity.CreateReply("");
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment()
                    {
                        ContentType = HeroCard.ContentType,
                        Content = card
                    });

                    await context.PostAsync(particle);
                    await context.PostAsync("Сведения о частице:\n\r" + title);
                    await context.PostAsync(reply);
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки с кодом в команде /newnonartpartical...");
                }               
            }
            else if ((activity.Text == "/help") || (activity.Text.ToLower().Contains("помощ")))
            {
                try
                {
                    //// calculate something for us to return
                    //int length = (activity.Text ?? string.Empty).Length;

                    //// return our reply to the user
                    //await context.PostAsync($"You sent {activity.Text} which was {length} characters");

                    await context.PostAsync("- Бот находится в очень ранней стадии разработки.\n\r \n\r- Доступные **команды**:\n\r" +
                        " * /newpartical - получение новой, случайно выбранной, \"частицы\" из всех имеющихся \"частиц\" в базе данных. " +
                        "После её получения можно добавить её в список избранных \"частиц\", нажав на соответствующую клавишу. " +
                        "Можно получить ссылку на скачивание книги, из которой изначально была создана эта \"частица\", в формате FB2, для чего также есть специальная кнопка." +
                        "Если \"частица\" некорректно обрывается или начинается, содержит неясные символы, слишком коротка, можно оправить сообщение об ошибке, нажав соответствующую предложенную кнопку." +
                        "Наконец, последняя кнопка позволят продублировать эту команду, снова получив новую \"частицу\".\n\r" +
                        " * /newpoempartical - получение новой стихотворной частицы. Команда аналогична предыдущей с разницей лишь в том, что \"частица\" выбирается случайно не из всех," +
                        "имеющихся в базе данных, а лишь из тех, что являются стихотворными или в большем соотношении к своему объёму содержат стихотворные строфы." +
                        "Также различия в том, что одна из предложенных после полученя клавиш предлагает получение новой именно стихотворной \"частицы\".\n\r" +
                        //"\n\r/newnonartpartical - получение новой не художественной частицы," +
                        //"\n\r/authors - список авторов книг," +
                        " * /favourites - список \"избранных\" \"частиц\". Для удобства сначала Вам будет предложен список книг, " +
                        "из которых Вы добавляли в избранное частицы, а из них затем уже можно будет выбрать избранные частицы.\n\r" +
                        " * /statistics - отображение общих значений статистики бота.\n\r" +
                        " * /help - помощь и прочие сведения.\n\r" +
                        "\n\rВсе **отзывы** можно оставлять, просто отправляя боту сообщения с припиской в любом месте сообщения слова **\"отзыв\"**." +
                        //"\n\rПомимо этого, есть и специальный почтовый адрес: **litclassic@protonmail.com**\n\r " +
                        "\n\rТакже существует специальный канал: t.me/litclassic");
                    //await context.PostAsync("Также существует специальный канал: t.me/litclassic"); 
                    //await context.PostAsync("Буду рад видеть все отзывы на litclassic@protonmail.com");

                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода команды /help...");
                }              
            }
            else if ((activity.Text == "/statistics") || (activity.Text.ToLower().Contains("статистик")))
            {
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();
                    List<string> totalStatistics = new List<string>();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    totalStatistics = currentConnection.GetTotalStatistics();
                    string statistic = String.Format("Общая статистика. *Не обновляется динамически*, изменения будут видны спустя время. Последнее обновление: **{12}**. \n\r \n\r" +
                        " * Количество книг: **{0}**\n\r" +
                        " * Количество \"частиц\": **{1}**\n\r" +
                        " * Процент покрытия общим содержанием \"частиц\" всего содержания книг: **{2}**\n\r" +
                        " * Процент стихов от общего содержания книг: **{3}**\n\r" +
                        " * Процент стихов от общего содержания \"частиц\": **{4}**\n\r" +
                        " * Число авторов: **{5}**\n\r" +
                        " * Количество жанров: **{6}**\n\r" +
                        " * Количество сообщений об ошибках: **{7}**\n\r" +
                        " * Количество запросов \"частиц\": **{8}**\n\r" +
                        " * Количество добавленных \"частиц\" в \"избранное\": **{9}**\n\r" +
                        //" - Количество предпринятых к чтению книг: {10}\n\r" +
                        " * Число пользователей, воспользовавшихся ботом: **{11}**", totalStatistics[0], totalStatistics[1], totalStatistics[13],
                        totalStatistics[11], totalStatistics[12], totalStatistics[3], totalStatistics[4], totalStatistics[6], totalStatistics[7],
                        totalStatistics[8], totalStatistics[9], totalStatistics[10], totalStatistics[14]);

                    await context.PostAsync(statistic);

                    // заканчивает беседу, освобождает память (насколько эффективно?)

                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода команды /statistics...");
                }
            }
            else if (activity.Text == "/authors")
            {
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();
                    List<string> listBooksAuthors = new List<string>();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    listBooksAuthors = currentConnection.GetBooksAuthors();
                    string booksAuthors = "";

                    foreach (string bookAuthor in listBooksAuthors)
                    {
                        booksAuthors += bookAuthor + "\n\r";
                    }

                    //await context.PostAsync(booksAuthors);

                    HeroCard booksAuthorsCard = new HeroCard("Авторы:");
                    booksAuthorsCard.Buttons = new List<CardAction>();

                    for (int iListBooksAuthors = 0; iListBooksAuthors < listBooksAuthors.Count; iListBooksAuthors++)
                    {
                        CardAction newCardAction = new CardAction();
                        newCardAction.Title = listBooksAuthors[iListBooksAuthors] /*bookAuthor.Split(' ')[0][0] + '.' + bookAuthor.Split(' ')[1][0] + ' ' + bookAuthor.Split(' ')[2]*/;
                        newCardAction.Type = ActionTypes.ImBack;
                        newCardAction.Value = "buttonAuthor" + iListBooksAuthors;

                        booksAuthorsCard.Buttons.Add(newCardAction);
                    }

                    var reply = activity.CreateReply("");
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment()
                    {
                        ContentType = HeroCard.ContentType,
                        Content = booksAuthorsCard
                    });

                    await context.PostAsync(reply);
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода команды /authors...");
                }          
            }
            else if ((activity.Text == "/favourites") || (activity.Text.ToLower().Contains("избран")))
            {
                try
                {
                    try
                    {
                        BotDBConnect currentConnection = new BotDBConnect();

                        currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                        // список получаемых данных из базы
                        List<string> listFavourites = new List<string>();
                        listFavourites = currentConnection.GetFavourits(activity.Conversation.Id);

                        // строка сообщения со списком книг
                        string stringBook = "Книги, из которых Вы выбирали избранные частицы:\n\r";
                        // переменная-разделитель
                        string[] stringSeparator = new string[] { "////" };

                        // заполнение строки сообщения со списком книг
                        for (int iListFavourites = 0; iListFavourites < listFavourites.Count(); iListFavourites++)
                        {
                            stringBook += " * **№" + (iListFavourites + 1) + ":** " + listFavourites[iListFavourites].Split(stringSeparator, StringSplitOptions.None)[0] + "\n\r";
                        }

                        var card = new HeroCard("Клавиша с соответствующим книге номером откроет список сохранённых избранных \"частиц\" этой книги.");
                        card.Buttons = new List<CardAction>();

                        // создание нужного количества клавиш
                        for (int iListFavourites = 0; iListFavourites < listFavourites.Count(); iListFavourites++)
                        {
                            CardAction newCardAction = new CardAction()
                            {
                                Title = "№" + Convert.ToString(iListFavourites + 1),
                                Type = ActionTypes.PostBack,
                                Value = "getFavouriteParticalsByBookID" + listFavourites[iListFavourites].Split(stringSeparator, StringSplitOptions.None).Last()
                            };

                            card.Buttons.Add(newCardAction);
                        }

                        var reply = activity.CreateReply("");
                        reply.Attachments = new List<Attachment>();
                        reply.Attachments.Add(new Attachment()
                        {
                            ContentType = HeroCard.ContentType,
                            Content = card
                        });

                        // отправка сообщения со списком книг
                        await context.PostAsync(stringBook);
                        // отправка сообщения с клавишами
                        await context.PostAsync(reply);
                    }
                    catch
                    {
                        await context.PostAsync("У Вас пока нет избранных частиц!");
                    }
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода команды /favourites...");
                }               
            }
            else if (activity.Text.Contains("download"))
            {
                try
                {
                    int bookID = Convert.ToInt32(activity.Text.Split(' ')[1]);
                    BotDBConnect currentConnection = new BotDBConnect();
                    // список с ссылкой на книгу и названием книги
                    List<string> bookLink = new List<string>();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    bookLink = currentConnection.GetBookLink(bookID);

                    await context.PostAsync(bookLink[1] + ".\n\r" + bookLink[0]);
                    //context.Done("");
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода команды книги...");
                }
            }
            else if (activity.Text.Contains("readNext"))
            {
                try
                {
                    int lineID = Convert.ToInt32(activity.Text.Split(' ')[1]);
                    int bookID = Convert.ToInt32(activity.Text.Split(' ')[2]);
                    string conversationID = activity.Conversation.Id;
                    string title;
                    string[] readNext = new string[2];

                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    readNext = currentConnection.ReadNext(lineID, conversationID, bookID);
                    title = BuildTitle(readNext[0]);

                    await context.PostAsync(readNext[1]);
                    await context.PostAsync("Сведения о частице:\n\r" + title);

                    //        var card = new HeroCard("Дальнейшие возможные действия:");
                    //        card.Buttons = new List<CardAction>()
                    //{
                    //        new CardAction()
                    //        {
                    //            Title = "Читать далее...",
                    //            Type = ActionTypes.ImBack,
                    //            Value = "readNext"
                    //        }
                    //};

                    //        var reply = activity.CreateReply("");
                    //        reply.Attachments = new List<Attachment>();
                    //        reply.Attachments.Add(new Attachment()
                    //        {
                    //            ContentType = HeroCard.ContentType,
                    //            Content = card
                    //        });

                    //        await context.PostAsync(reply);
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки с кодом чтения книги далее...");
                }               
            }
            else if (activity.Text == "addParticalToFavourites")
            {
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();
                    currentConnection.WriteNewFavouriteParticle(activity.Conversation.Id);
                    await context.PostAsync("Частица добавлена в избранное!");
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода добавления частицы в избранное...");
                }
            }
            else if (activity.Text == "reportWord")
            {
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();
                    currentConnection.WriteNewWordReportByConversationID(activity.Conversation.Id);
                    await context.PostAsync("Сообщение об ошибке отправлено!");
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода отправления сообщения об ошибке...");
                }
            }
            else if (activity.Text == "reportPartical")
            {
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();
                    currentConnection.WriteNewParticleReportByConversationID(activity.Conversation.Id);
                    await context.PostAsync("Сообщение об ошибке отправлено!");
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода отправления сообщения об ошибке...");
                }
            }
            else if (activity.Text == "buttonAuthor")
            {
                await context.PostAsync("Ага, понял.");
            }
            else if (activity.Text.Contains("getFavouriteParticalsByBookID"))
            {
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    // список получаемых данных из базы
                    List<int> listFavouriteParticlesID = new List<int>();
                    List<string> listFavouriteParticlesTitles = new List<string>();
                    // присвоение bookID
                    int bookID = Convert.ToInt32(activity.Text.Split('D')[1]);
                    listFavouriteParticlesID = currentConnection.GetFavouriteParticlesID(Convert.ToInt32(bookID), activity.Conversation.Id);
                    // строка сообщения со списком книг
                    string stringFavouriteParticles = "Избранные Вами частицы:\n\r";
                    // переменная-разделитель
                    //string[] stringSeparator = new string[] { "////" };

                    // заполнение строки сообщения со списком заголовков частиц
                    //for (int iListFavouriteParticlasByBookID = 0; 
                    //    iListFavouriteParticlasByBookID < listFavouriteParticalsID.Count(); 
                    //    iListFavouriteParticlasByBookID++)
                    //{
                    //    stringFavouriteParticals += "**№" + (iListFavouriteParticlasByBookID + 1) + 
                    //        ":** " + listFavouriteParticalsID[iListFavouriteParticlasByBookID].Split(stringSeparator, StringSplitOptions.None)[0] + "\n\r";
                    //}

                    listFavouriteParticlesTitles = currentConnection.GetParticlesTitles(listFavouriteParticlesID);

                    for (int iListFavouriteParticlesTitles = 0;
                        iListFavouriteParticlesTitles < listFavouriteParticlesTitles.Count;
                        iListFavouriteParticlesTitles++)
                    {
                        stringFavouriteParticles += "* **№" + (iListFavouriteParticlesTitles + 1)
                            + ":** " + listFavouriteParticlesTitles[iListFavouriteParticlesTitles] + "\n\r";
                    }

                    var card = new HeroCard("Клавиша с соответствующим частице номером пришлёт выбранную частицу.");
                    card.Buttons = new List<CardAction>();

                    // создание нужного количества клавиш
                    for (int iListFavouriteParticlesID = 0;
                        iListFavouriteParticlesID < listFavouriteParticlesID.Count();
                        iListFavouriteParticlesID++)
                    {
                        CardAction newCardAction = new CardAction()
                        {
                            Title = "№" + Convert.ToString(iListFavouriteParticlesID + 1),
                            Type = ActionTypes.PostBack,
                            Value = "getPartical" + listFavouriteParticlesID[iListFavouriteParticlesID]
                        };

                        card.Buttons.Add(newCardAction);
                    }

                    //CardAction lastCardAction = new CardAction()
                    //{
                    //    Title = "Назад, в предыдущее меню",
                    //    Type = ActionTypes.PostBack,
                    //    Value = "/favourites"
                    //};

                    //card.Buttons.Add(lastCardAction);

                    var reply = activity.CreateReply("");
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment()
                    {
                        ContentType = HeroCard.ContentType,
                        Content = card
                    });

                    // отправка сообщения со списком заголовков частиц
                    await context.PostAsync(stringFavouriteParticles);
                    // отправка сообщения с клавишами
                    await context.PostAsync(reply);
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода получения списка книг, из которых были выбраны избранные частицы...");
                }               
            }
            else if (activity.Text.Contains("getPartical"))
            {
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();

                    // список получаемых данных из базы
                    List<string> particle = new List<string>();
                    // присвоение particleID
                    int particleID = Convert.ToInt32(activity.Text.Split('l')[1]);
                    particle = currentConnection.GetParticle(particleID);

                    string line = particle[0];
                    string title = particle[1];
                    int indeLastLine = Convert.ToInt32(particle[2]);
                    int bookID = Convert.ToInt32(particle[4]);
                    var card = new HeroCard("Дальнейшие возможные действия:");
                    card.Buttons = new List<CardAction>()
        {
                    new CardAction()
                {
                    Title = "Удалить из избранных данную частицу.",
                    Type = ActionTypes.PostBack,
                    Value = "deleteFavouritePartical " + particleID
                },
                new CardAction()
                {
                    Title = "Скачать книгу.",
                    Type = ActionTypes.PostBack,
                    Value = "download " + bookID
                }
        };

                    var reply = activity.CreateReply("");
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment()
                    {
                        ContentType = HeroCard.ContentType,
                        Content = card
                    });

                    await context.PostAsync(line);
                    await context.PostAsync("Сведения о частице:\n\r" + title);
                    await context.PostAsync(reply);
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода команды получения частицы из избранного...");
                }              
            }
            else if (activity.Text.Contains("deleteFavouritePartical"))
            {
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();
                    int particleID = Convert.ToInt32(activity.Text.Split(' ')[1]);

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();
                    currentConnection.DeleteFavouriteParticle(particleID, activity.Conversation.Id);

                    var card = new HeroCard("Данная частица успешно удалена из списка избранных.");
                    card.Buttons = new List<CardAction>()
        {
                    new CardAction()
                {
                    Title = "Показать новый список избранных частиц.",
                    Type = ActionTypes.PostBack,
                    Value = "/favourites"
                }
        };

                    var reply = activity.CreateReply("");
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment()
                    {
                        ContentType = HeroCard.ContentType,
                        Content = card
                    });

                    await context.PostAsync(reply);
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода команды удаления частицы из избранного...");
                }              
            }
            else if (activity.Text.ToLower().Contains("отзыв"))
            {
                try
                {
                    BotDBConnect currentConnection = new BotDBConnect();

                    currentConnection.SetSQLConnectionToAzureDBLitClassicBooks();
                    currentConnection.WriteNewFeedbackMessage(activity.Conversation.Id, activity.Text);
                    await context.PostAsync("Благодарю за написанный отзыв!");
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода отправления отзыва...");
                }
            }
            else if (activity.Text == "Test")
            {


                var reply = activity.CreateReply("I have colors in mind, but need your help to choose the best one.");
    //            reply.Type = ActivityTypes.Message;
    //            reply.TextFormat = TextFormatTypes.Plain;
    //            //reply.AddKeyboardCard("text");

    //            reply.SuggestedActions = new SuggestedActions()
    //            {
    //                Actions = new List<CardAction>()
    //{
    //    new CardAction(){ Title = "Blue", Type=ActionTypes.ImBack, Value="BlueBlue" },
    //    new CardAction(){ Title = "Red", Type=ActionTypes.ImBack, Value="RedRed" },
    //    new CardAction(){ Title = "Green", Type=ActionTypes.ImBack, Value="GreenGreen" }
    //}
    //            };

                reply.ChannelData = " \"channelData\" : {\"method\": \"editMessageReplyMarkup\",\"parameters\": {\"reply_markup\": {\"keyboard\": {\"KeboardButton\": \"Red\"}\"one_time_keyboard\": \"true\"}}}\" ";

                await context.PostAsync(reply);

                //activity.ChannelData =
            }
            else if ((activity.Text.ToLower() == "-us") & (activity.Conversation.Id == Convert.ToString(205828645)))
            {
                try
                {
                    BotDBConnect currentBookDBConnect = new BotDBConnect();

                    currentBookDBConnect.SetSQLConnectionToAzureDBLitClassicBooks();
                    currentBookDBConnect.UpdateTotalStatisticsShort();
                    await context.PostAsync("Статистику успешно обновил!");
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки в исполнении кода команды быстрого обновления статистики...");
                }         
            }
            else 
            {
                try
                {
                    await context.PostAsync("Ботом можно пользоваться, отправляя ему следующие **команды**:\n\r" +
                        //"**Основные команды:**\n\r" +
                        " * /newpartical - бот пришлёт случайно выбранную частицу;\n\r" +
                        " * /newpoempartical - бот пришлёт случайно выбранную стихотворную частицу;\n\r" +
                        " * /favourites - бот пришлёт список книг, частицы которых Вы добавили в свой список избранных; из этого списка затем можно выбрать частицы, добавленные Вами;\n\r" +
                        //"**Прочие команды:**\n\r" +
                        " * /statistics - бот пришлёт данные статистики его пользования и его базы книг;\n\r" +
                        " * /help - бот пришлёт справочную и прочую информацию о себе.");
                    //await context.PostAsync("Доступные команды:" +
                    //    "\n\r/newpartical - получение новой частицы," +
                    //    "\n\r/authors - список авторов книг," +
                    //    "\n\r/favourites - список \"избранных\" \"частиц\"," +
                    //    "\n\r/statistics - отображение общей статистики," +
                    //    "\n\r/help - помощь и прочие сведения.");
                }
                catch
                {
                    await context.PostAsync("Какие-то неполадки с кодом обработки неизвестных команд...");
                }               
            }

            context.Wait(MessageReceivedAsync);
            //var oMycustomclassname = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(Json Object);
        }




        private string BuildTitle(string inputLongTitle)
        {
            List<Title> listTitles = new List<Title>();
            string[] listLines = inputLongTitle.Split(new[] { "\\\\" }, StringSplitOptions.None);

            // убирает лишний последний элемент массива, который неминуемо возникает пустым, т.к. заголовок оканчивается на "\\\\"
            Array.Resize(ref listLines, listLines.Length - 1);

            // -- формирование списков частей заголовка строк --
            string particleTitle = "";
            List<string> listFinalTitles = new List<string>();
            // список списка отдельных частей заголовков
            List<List<string>> listPartsOfTitles = new List<List<string>>();
            // длинный полный список со всеми заголовками в упорядоченном порядке
            //List<string> listTitles = new List<string>();

            foreach (string line in listLines)
            {
                string[] title;
                title = line.Split(';');
                List<string> listStringTitles = new List<string>();

                // убирает лишний последний элемент массива, который неминуемо возникает пустым, т.к. заголовок оканчивается на ";"
                Array.Resize(ref title, title.Length - 1);

                // переделка массива в список
                foreach (string titleString in title)
                {
                    listStringTitles.Add(titleString);
                }

                listPartsOfTitles.Add(listStringTitles);
            }

            // -- формирование списков частей заголовка строк --



            // -- формирование первой версии заголовка --
            //string compareTitle = listPartsOfTitles[0][0];
            //int previousCompareIndex = compareTitleIndex;
            Title firstTitle = new Title();
            //List<string> tempPartsOfTitle = new List<string>();

            //// цикл на добавление в список всех частей одного заголовка, не включая первый
            //for (int iPartOfTitle = 1; iPartOfTitle < listPartsOfTitles[0].Count(); iPartOfTitle++)
            //{
            //    tempPartsOfTitle.Add(listPartsOfTitles[0][iPartOfTitle]);
            //}

            //listFuturePartsOfTitles.Add(tempPartsOfTitle);
            listTitles.Add(firstTitle);
            listTitles.Last().SetListPartsOfTitles(listPartsOfTitles);
            //firstTitle.SetTitleString(compareTitle);
            firstTitle.CreateTitle();

            // создание строки заголовка
            particleTitle = BuildParticlesTitle(firstTitle);
            // -- формирование первой версии заголовка --



            // -- формирование окончательной версии заголовка --
            string[] largePartsOfTitle;
            largePartsOfTitle = particleTitle.Split(';');

            // убирает лишний последний элемент массива, который неминуемо возникает пустым, т.к. заголовок оканчивается на ";"
            Array.Resize(ref largePartsOfTitle, largePartsOfTitle.Length - 1);

            for (int iLargePartsOfTitle = 0; iLargePartsOfTitle < largePartsOfTitle.Count(); iLargePartsOfTitle++)
            {
                string[] componentOfTitle;
                componentOfTitle = largePartsOfTitle[iLargePartsOfTitle].Split(' ');

                if (componentOfTitle.Count() > 2)
                {
                    if ((componentOfTitle[2] == "раздел") | (componentOfTitle[2] == "стих") | (componentOfTitle[2] == "строфа")
                    | (componentOfTitle[2] == "абзац") | (componentOfTitle[2] == "эпиграф") | (componentOfTitle[2] == "аннотация") | (componentOfTitle[2] == "цитата"))
                    {
                        // номер первой однотипной части заголовка
                        string firstIndexComponent = componentOfTitle[1];
                        // номер последней однотипной части заголовка
                        string lastIndexComponent = componentOfTitle[1];
                        // однотипная часть заголовка, т.е. "стих", "раздел" и т.п.
                        string component = componentOfTitle[2];
                        // строка заголовков, которая затем будет заменяться в общем заголовке на объединённый
                        string partForReplace = firstIndexComponent + ' ' + component + "; ";

                        iLargePartsOfTitle++;


                        while (((iLargePartsOfTitle < largePartsOfTitle.Count()) && (largePartsOfTitle[iLargePartsOfTitle].Split(' ').Count() > 2))
                            && (largePartsOfTitle[iLargePartsOfTitle].Split(' ')[2] == component))
                        {
                            lastIndexComponent = largePartsOfTitle[iLargePartsOfTitle].Split(' ')[1];
                            partForReplace += largePartsOfTitle[iLargePartsOfTitle].Split(' ')[1] + ' ' + largePartsOfTitle[iLargePartsOfTitle].Split(' ')[2] + "; ";

                            iLargePartsOfTitle++;
                        }

                        // если однотипная часть заголовка лишь одна, т.е. объединять нечего
                        if (firstIndexComponent != lastIndexComponent)
                        {
                            particleTitle = ReplaceFirst(particleTitle, partForReplace, firstIndexComponent + '-' + lastIndexComponent + ' ' + component + "; ");
                        }

                        iLargePartsOfTitle--;
                    }
                }
            }

            //particalTitle = particalTitle.Replace("; ", ";\n");
            // -- формирование окончательной версии заголовка --



            // добавление строки заголовка в общий список заголовков
            return particleTitle;
        }
        private string BuildParticlesTitle(Title title)
        {
            string titleString = "";
            titleString += title.GetTitleString();

            //if (title.GetListTitles().Count() != 0)
            //{
            foreach (Title elementTitle in title.GetListTitles())
            {
                titleString += BuildParticlesTitle(elementTitle);
            }
            //}

            return titleString;
        }
        private string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);

            if (pos < 0)
            {
                return text;
            }

            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}