﻿using System;
using System.Collections.Generic;
using System.Linq;
using TemplateMethod.Core;
using TemplateMethod.Core.ReqA;

namespace TemplateMethod
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            List<Task> icpcTasks = new List<Task>()
            {
                new Task("A", "Description A", 1),
                new Task("B", "Description B", 1),
                new Task("C", "Description C", 1),
                new Task("D", "Description D", 1),
                new Task("E", "Description E", 1),
            };

            List<Participant> icpcParticipants = new List<Participant>()
            {
                new Participant("user1" ),
                new Participant("user2" ),
                new Participant("user3" ),
                new Participant("user4" ),
                new Participant("user5" ),
                new Participant("user6" ),
                new Participant("user7" ),
                new Participant("user8" ),
                new Participant("user9" ),
                new Participant("user10"),
            };

            List<Task> cfTasks = new List<Task>()
            {
                new Task("A", "Description A", 500),
                new Task("B", "Description B", 1000),
                new Task("C", "Description C", 1500),
                new Task("D", "Description D", 2000),
                new Task("E", "Description E", 2500),
            };

            List<Participant> cfParticipants = new List<Participant>()
            {
                new Participant("user1" ),
                new Participant("user2" ),
                new Participant("user3" ),
                new Participant("user4" ),
                new Participant("user5" ),
                new Participant("user6" ),
                new Participant("user7" ),
                new Participant("user8" ),
                new Participant("user9" ),
                new Participant("user10"),
            };

            var icpcResults = icpcParticipants.ToDictionary(p => p, p => icpcTasks.ToDictionary(t => t, t => GenerateResult(t)));
            var cfResults = cfParticipants.ToDictionary(p => p, p => cfTasks.ToDictionary(t => t, t => GenerateResult(t)));

            Contest icpcContest = new IcpcContest(icpcParticipants, icpcTasks, icpcResults);
            Contest cfContest = new CodeforcesContest(cfParticipants, cfTasks, cfResults);
            
            Console.WriteLine("ICPC contest scoreboard: ");
            Console.WriteLine(icpcContest.Scoreboard);
            Console.WriteLine("");
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine("");
            Console.WriteLine("Codeforces contest scoreboard: ");
            Console.WriteLine(cfContest.Scoreboard);

            // ====================================================================================================================

            List<Participant> participants = new List<Participant>()
            {
                new Participant("Chad"),
                new Participant("Alice"),
                new Participant("Donovan"),
                new Participant("Fishy"),
                new Participant("Bob"),
                new Participant("Greg"),
                new Participant("Elmo"),
            };
            ParticipantList alphabeticList = new AlphabeticParticipantList();
            ParticipantList lengthBasedList = new UsernameLengthBasedParticipantList();

            Console.WriteLine("Alphabetic ordering:");
            foreach(var p in alphabeticList.ReorderParticipants(participants))
            {
                Console.WriteLine(p.Username);
            }

            Console.WriteLine("Username length-based ordering:");
            foreach(var p in lengthBasedList.ReorderParticipants(participants))
            {
                Console.WriteLine(p.Username);
            }

            //======================================================================================================================
            string allIcpcTasks = string.Join("\n------------------------------\n", icpcContest.RenderedTasks);
            string allCfTasks = string.Join("\n------------------------------\n", cfContest.RenderedTasks);

            Console.WriteLine(allIcpcTasks);
            Console.WriteLine("");
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine("");
            Console.WriteLine(allCfTasks);

            //======================================================================================================================
            Task oldTask = new Task("Old task", "This is the old, unedited task", 1500);
            Task newTask = new Task("New task", "This is the new and shiny task.", 2000);
            TaskEditor htmlEditor = new HtmlTaskEditor(oldTask);
            TaskEditor markdownEditor = new MarkdownTaskEditor(newTask);
            Console.WriteLine("HTML before:");
            Console.WriteLine(htmlEditor.RenderedTask);
            htmlEditor.EditTask(newTask);
            Console.WriteLine("HTML after:");
            Console.WriteLine(htmlEditor.RenderedTask);
            Console.WriteLine();
            Console.WriteLine("Markdown before:");
            Console.WriteLine(markdownEditor.RenderedTask);
            markdownEditor.EditTask(newTask);
            Console.WriteLine("Markdown after:");
            Console.WriteLine(markdownEditor.RenderedTask);
        }

        static Result GenerateResult(Task task)
        {
            bool isSolved = random.Next(2) == 1;
            int time = random.Next(121);
            int wrongSubmissionCount = random.Next(20);
            return new Result(isSolved, time, wrongSubmissionCount);
        }
    }
}