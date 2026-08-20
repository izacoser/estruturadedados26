using System.Globalization;

/* Exemplo dos nomes dos meses do ano*/

string[] months = new string[12];
for (int i = 1; i <=12; i++) {
    DateTime firstDay = new DateTime(DateTime.Now.Year, i, 1);

    DateTime lastDay = firstDay.AddDays(-1);

    string monthName = firstDay.ToString("MMMM", CultureInfo.CreateSpecificCulture("pt-BR"));

    months [i - 1] = monthName;
}

foreach (string monthName in months) {
    Console.WriteLine ($"--> {monthName}");
}


