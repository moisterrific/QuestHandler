using System;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using System.IO;
using Microsoft.Xna.Framework;

namespace QuestHandler
{
    [ApiVersion(2, 1)]
    public class QuestHandler : TerrariaPlugin
    {
        public override string Author => "munukhu";

        public override string Description => "A Simple Quest Handler Plugin";

        public override string Name => "QuestHandler";
        public override Version Version
        {
            get { return new Version("1.0.0"); }
        }

        public QuestHandler(Main game) : base(game)
        {
        }

        public override void Initialize()
        {
            QuestConfig.SetupFile();
            Commands.ChatCommands.Add(new Command("", Quest, "quest"));
        }
        private static void Quest(CommandArgs args)
        {
            if (args.Parameters.Count < 1)
            {
                args.Player.SendInfoMessage("Type {0}quest daily to see active daily quest", Commands.Specifier);
                args.Player.SendInfoMessage("Type {0}quest weekly to see active weekly quest", Commands.Specifier);
                if (args.Player.HasPermission("questhandler.quest.change"))
                {
                    args.Player.SendInfoMessage("Type {0}quest changedaily to change active daily quest", Commands.Specifier);
                    args.Player.SendInfoMessage("Type {0}quest changeweekly to change active weekly quest", Commands.Specifier);
                }
                return;
            }
            if (args.Parameters[0].ToLower() == "daily" || args.Parameters[0].ToLower() == "d")
            {
                if (File.Exists(QuestConfig.QuestDailyPath))
                {
                    string[] lines = File.ReadAllLines(QuestConfig.QuestDailyPath);
                    for (int i = 0; i < lines.Length; i += 3)
                    {
                        var mission = lines[i];
                        var reward = lines[i + 1];
                        var deadline = (lines[i + 2]);
                        args.Player.SendMessage(String.Format("===== Daily Quest =====\n[i/s1:6][c/26C6DA:Mission:] {0}\n[i/s1:4131][c/26C6DA:Reward:] {1}\n[i/s1:3099][c/26C6DA: Deadline:] {2}", mission, reward, deadline), Color.White);
                    }
                }
                return;
            }
            if (args.Parameters[0].ToLower() == "weekly" || args.Parameters[0].ToLower() == "w")
            {
                if (File.Exists(QuestConfig.QuestWeeklyPath))
                {
                    string[] lines = File.ReadAllLines(QuestConfig.QuestWeeklyPath);
                    for (int i = 0; i < lines.Length; i += 3)
                    {
                        var mission = lines[i];
                        var reward = lines[i + 1];
                        var deadline = (lines[i + 2]);
                        args.Player.SendMessage(String.Format("===== Weekly Quest =====\n[i/s1:6][c/26C6DA:Mission:] {0}\n[i/s1:4131][c/26C6DA:Reward:] {1}\n[i/s1:3099][c/26C6DA: Deadline:] {2}", mission, reward, deadline), Color.White);
                    }
                }
                return;
            }
            if (args.Parameters[0].ToLower() == "changedaily" || args.Parameters[0].ToLower() == "cd")
            {
                if (!args.Player.HasPermission("questhandler.quest.change"))
                {
                    args.Player.SendErrorMessage("You don't have permission to use this command.");
                    return;
                }
                else if (args.Parameters.Count < 4)
                {
                    args.Player.SendErrorMessage("Invalid syntax! Use {0}quest changedaily <mission> <reward> <deadline>", Commands.Specifier);
                    return;
                }
                if (File.Exists(QuestConfig.QuestDailyPath))
                {
                    string[] questdata = { args.Parameters[1], args.Parameters[2], args.Parameters[3] };
                    using (StreamWriter writer = new StreamWriter(QuestConfig.QuestDailyPath))
                    {
                        foreach (string quest in questdata)
                        {
                            writer.WriteLine(quest);
                        }
                        args.Player.SendSuccessMessage("Daily quest has been successfully changed");
                        writer.Close();
                    }
                    return;
                }
            }
            if (args.Parameters[0].ToLower() == "changeweekly" || args.Parameters[0].ToLower() == "cw")
            {
                if (!args.Player.HasPermission("questhandler.quest.change"))
                {
                    args.Player.SendErrorMessage("You don't have permission to use this command.");
                    return;
                }
                else if (args.Parameters.Count < 4)
                {
                    args.Player.SendErrorMessage("Invalid syntax! Use: {0}quest changeweekly <mission> <reward> <deadline>", Commands.Specifier);
                    return;
                }
                if (File.Exists(QuestConfig.QuestWeeklyPath))
                {
                    string[] questdata = { args.Parameters[1], args.Parameters[2], args.Parameters[3] };
                    using (StreamWriter writer = new StreamWriter(QuestConfig.QuestWeeklyPath))
                    {
                        foreach (string quest in questdata)
                        {
                            writer.WriteLine(quest);
                        }
                        args.Player.SendSuccessMessage("Weekly quest has been successfully changed");
                        writer.Close();
                    }
                    return;
                }
            }
            else
            {
                args.Player.SendInfoMessage("Type {0}quest daily to see active daily quest", Commands.Specifier);
                args.Player.SendInfoMessage("Type {0}quest weekly to see active weekly quest", Commands.Specifier);
                if (args.Player.HasPermission("questhandler.quest.change"))
                {
                    args.Player.SendInfoMessage("Type {0}quest changedaily to change active daily quest", Commands.Specifier);
                    args.Player.SendInfoMessage("Type {0}quest changeweekly to change active weekly quest", Commands.Specifier);
                }
                return;
            }
        }
    }
}
