namespace ZyakiCalculator.Core.Entity
{
    class ZyakiConvertor(int value)
    {
        private readonly int value = value;
        private readonly List<string> result = [];
        private readonly Dictionary<string, int> numeration = new()
        {
            { "*Шмяк", 10 },
            { "*Полушмяк", 5 },
            { "Зяки-зяки", 2 },
            { "Зяки", 1 }
        };

        private string MinNumerationName => numeration.MinBy(kvp => kvp.Value).Key;

        public void Process()
        {
            int calcValue = value;

            if (calcValue <= 0)
                return;

            foreach (KeyValuePair<string, int> entry in numeration)
            {
                if (calcValue / entry.Value > 0)
                {
                    if (entry.Key.Contains('*'))
                        if (!result.Contains(PrepareName(entry.Key)))
                            result.Add(PrepareName(MinNumerationName));

                    while (calcValue / entry.Value > 0)
                    {
                        int whole = calcValue / entry.Value;
                        int remainder = calcValue % entry.Value;

                        calcValue = (whole - 1) * entry.Value + remainder;

                        result.Add(PrepareName(entry.Key));

                        if (calcValue == 1)
                        {
                            result.Add(PrepareName(MinNumerationName));
                            break;
                        }
                    }
                }
            }
        }

        public string Result() => result.Count > 0 ? result.Aggregate((a, b) => a + " " + b) : "_|_";

        private static string PrepareName(string name) => name.Replace("*", String.Empty);
    }
}
