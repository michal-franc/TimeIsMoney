using System;

namespace TimeIsMoney
{
    [Serializable]
    public class TaskBin 
    {
        public string Address { get; set; }
        public string Name { get; set; }

        public string DisplayMember
        {
            get
            {
                return "Name";
            }
        }
    }
}