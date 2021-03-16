using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Adventures
{
    public class Adventure
    {
        public string Title { get; set; }
        public string gameTitleDescription { get; set; }
        public string firstChapterDescription { get; set; }
        public string secondChapterDescription { get; set; }
        public string secondChapterRiddle { get; set; }
        public string secondChapterPropAnswer { get; set; }
        public string thirdChapterDescription { get; set; }
        public string fourthChapterDescription { get; set; }
        public string fifthChapterDescription { get; set; }
        public string playerIsDead { get; set; }

        public Adventure()
        {

        }
    }
}
