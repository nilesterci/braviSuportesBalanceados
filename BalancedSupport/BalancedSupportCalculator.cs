namespace BalancedSupport
{
    public class BalancedSupportCalculator
    {
        private static readonly (char init, char end)[] supports = {
            ('(', ')'),
            ('[',  ']'),
            ('{', '}'),
        };

        private bool checkIsOpenSupport(char value)
        {
            return supports.Any(support => support.init == value);
        }

        private (char init, char end)? FindPairByInitSupport(char initSupport)
        {
            return supports
                    .Where(support => support.init == initSupport)
                    .FirstOrDefault();
        }

        private void AddSupport(Stack<char> supports, char newSupport)
        {
            supports.Push(newSupport);
        }

        private bool TryRemoveSupport(Stack<char> supports, char closedSupport)
        {
            char lastOpenedSupport = supports.FirstOrDefault();
            var pairSupport = FindPairByInitSupport(lastOpenedSupport);

            if (supports.Count == 0 ||
                //pairSupport == null ||
                //pairSupport?.init != lastOpenedSupport ||
                pairSupport?.end != closedSupport)
            {
                return false;
            }

            supports.Pop();
            return true;
        }



        public bool Execute(string value)
        {
            Stack<char> supports = new Stack<char>();

            foreach (var symbol in value)
            {
                if (checkIsOpenSupport(symbol))
                {
                    AddSupport(supports, symbol);
                    continue;
                }

                if (!TryRemoveSupport(supports, symbol))
                    return false;
            }

            int remainingOpenBrackets = supports.Count;
            return remainingOpenBrackets == 0;

        }
    }
}
