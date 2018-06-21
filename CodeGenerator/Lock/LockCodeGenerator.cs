using System;

namespace Room
{
    class LockCodeGenerator : ICodeGenerator
    {
        private string lockvalue;
        private string unlockvalue;

        public void SetLockValue(string value)
        {
            lockvalue = value;
        }

        public void SetUnlockValue(string value)
        {
            unlockvalue = value;
        }

        public void RemoveLockValue(string value)
        {
            lockvalue = String.Empty;
        }

        public void RemoveUnlockValue(string value)
        {
            unlockvalue = String.Empty;
        }
    }
}
