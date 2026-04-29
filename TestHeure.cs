using System;
using System.Diagnostics;
using System.IO;

class TestHeure
{
	static void Main()
	{
		string exe = Path.Combine("bin", "Debug", "net8.0", "HeurePourAssistantVocal.exe");

		bool ok1 = RunSingleTest(exe, new[] { "07:00" }, "sept heures du matin", out string out1);
		Console.WriteLine(ok1 ? "Test 1 : Réussi" : "Test 1 : Echec");

		bool ok2 = RunSingleTest(exe, new[] { "00:00" }, "minuit", out string out2);
		Console.WriteLine(ok2 ? "Test 2 : Réussi" : "Test 2 : Echec");

		bool ok3 = RunSingleTest(exe, new[] { "12:00" }, "midi", out string out3);
		Console.WriteLine(ok3 ? "Test 3 : Réussi" : "Test 3 : Echec");

		bool ok4 = RunSingleTest(exe, new[] { "09:15" }, "neuf heures et quart du matin", out string out4);
		Console.WriteLine(ok4 ? "Test 4 : Réussi" : "Test 4 : Echec");

		bool ok5 = RunSingleTest(exe, new[] { "10:40" }, "onze heures moins vingt du matin", out string out5);
		Console.WriteLine(ok5 ? "Test 5 : Réussi" : "Test 5 : Echec");

		bool ok6 = RunSingleTest(exe, new[] { "", "07:00" }, "sept heures du matin", out string out6);
		Console.WriteLine(ok6 ? "Test 6 : Réussi" : "Test 6 : Echec");

		bool ok7 = RunSingleTest(exe, new[] { "abc", "00:00" }, "minuit", out string out7);
		Console.WriteLine(ok7 ? "Test 7 : Réussi" : "Test 7 : Echec");

		bool ok8 = RunSingleTest(exe, new[] { "7:00", "12:00" }, "midi", out string out8);
		Console.WriteLine(ok8 ? "Test 8 : Réussi" : "Test 8 : Echec");
		Console.WriteLine();
	}

	static bool RunSingleTest(string exePath, string[] inputs, string expectedPart, out string output)
	{
		output = "";

		try
		{
			var psi = new ProcessStartInfo(exePath)
			{
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true,
			};

			using (var p = Process.Start(psi))
			{
				foreach (var line in inputs)
				{
					p.StandardInput.WriteLine(line);
				}
				p.StandardInput.Close();

				string outText = p.StandardOutput.ReadToEnd();
				p.WaitForExit();
				output = outText;

				return outText.IndexOf(expectedPart, StringComparison.OrdinalIgnoreCase) >= 0;
			}
		}
		catch (Exception ex)
		{
			output = "Erreur : " + ex.Message;
			return false;
		}
	}
}

