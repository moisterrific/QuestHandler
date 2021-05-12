using System.IO;
using TShockAPI;

namespace QuestHandler
{
	public class QuestConfig
	{
		internal static string QuestDailyPath
		{
			get { return Path.Combine(TShock.SavePath, "QuestHandler", "quest-daily.txt"); }
		}
		internal static string QuestWeeklyPath
		{
			get { return Path.Combine(TShock.SavePath, "QuestHandler", "quest-weekly.txt"); }
		}
		public static void CreateIfNot(string file, string data = "")
		{
			if (!File.Exists(file))
			{
				File.WriteAllText(file, data);
			}
		}
		public static void SetupFile()
		{
			if (!Directory.Exists(Path.Combine(TShock.SavePath, "QuestHandler")))
			{
				Directory.CreateDirectory(Path.Combine(TShock.SavePath, "QuestHandler"));
			}
			CreateIfNot(QuestDailyPath, "Bring 100 Dirt\n10 Platinum Coin\n1 Mei 2021 09:00");
			CreateIfNot(QuestWeeklyPath, "Bring 100 Dirt\n10 Platinum Coin\n1 Mei 2021 09:00");
		}
	}
}
