using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNPAssignment1.Data
{

    public class StatisticsService : IstatisticsService
    {
        public List<Family> Families { get; set; }
        public List<Adult> Adults { get; set; }

        public int avgAge()
        {
            int i = 0;
            foreach(var a in Adults)
            {
                i += a.Age;
            }
            return i/Adults.Count;
        }

        public string avgEye()
        {
            List<string> g = new List<string>();
            foreach (var a in Adults)
            {
                g.Add(a.EyeColor);
            }

            return g.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        }

        public string avgGender()
        {
            List<string> g = new List<string>();
            foreach(var a in Adults)
            {
                g.Add(a.Sex);
            }

            return g.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        }

        public string avgHair()
        {
            List<string> g = new List<string>();
            foreach (var a in Adults)
            {
                g.Add(a.HairColor);
            }

            return g.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        }

        public int avgHeight()
        {
            int i = 0;
            foreach (var a in Adults)
            {
                i += a.Height;
            }
            return i / Adults.Count;
        }

        public string avgJob()
        {

            List<string> g = new List<string>();
            foreach (var a in Adults)
            {
                g.Add(a.JobTitle);
            }

            return g.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        }

        public float avgWeight()
        {
            float i = 0;
            foreach (var a in Adults)
            {
                i += a.Weight;
            }
            return (float)Math.Round((decimal)(i / Adults.Count), 2);
        }

        public void setFamily(IList<Family> Families)
        {
            this.Families = null;
            Adults = new List<Adult>();

            this.Families = (List<Family>)Families;
            foreach(var f in this.Families)
            {
                foreach(var a in f.Adults)
                {
                    Adults.Add(a);
                }
            }
        }
    }
}
