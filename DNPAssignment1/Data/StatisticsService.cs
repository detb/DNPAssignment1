using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DNPAssignment1.Data
{

    public class StatisticsService : IstatisticsService
    {
        public List<Family> Families { get; set; }
        public List<Adult> Adults { get; set; }
        public List<Adult> Men { get; set; }
        public List<Adult> Women { get; set; }

        public int avgAge(string str)
        {
            List<Adult> l = new List<Adult>();
            if (str == "m")
                l = Men;
            else
                l = Women;
            int i = 0;
            foreach(var a in l)
            {
                i += a.Age;
            }
            return i/l.Count;
        }

        public string avgEye(string str)
        {
            List<Adult> l = new List<Adult>();
            List<string> g = new List<string>();
            if (str == "m")
                l = Men;
            else
                l = Women;
            foreach (var a in l)
            {
                g.Add(a.EyeColor);
            }

            return g.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        }

        public string avgGender(string str)
        {
            List<string> g = new List<string>();
            List<Adult> l = new List<Adult>();
            if (str == "m")
                l = Men;
            else
                l = Women;
            foreach (var a in l)
            {
                g.Add(a.Sex);
            }

            return g.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        }

        public string avgHair(string str)
        {
            List<string> g = new List<string>();
            List<Adult> l = new List<Adult>();
            if (str == "m")
                l = Men;
            else
                l = Women;
            foreach (var a in l)
            {
                g.Add(a.HairColor);
            }

            return g.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        }

        public int avgHeight(string str)
        {
            int i = 0;
            List<Adult> l = new List<Adult>();
            if (str == "m")
                l = Men;
            else
                l = Women;
            foreach (var a in l)
            {
                i += a.Height;
            }
            return i / l.Count;
        }

        public string avgJob(string str)
        {

            List<string> g = new List<string>();
            List<Adult> l = new List<Adult>();
            if (str == "m")
                l = Men;
            else
                l = Women;
            foreach (var a in l)
            {
                g.Add(a.JobTitle);
            }

            return g.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        }

        public float avgWeight(string str)
        {
            float i = 0;
            List<Adult> l = new List<Adult>();
            if (str == "m")
                l = Men;
            else
                l = Women;
            foreach (var a in l)
            {
                i += a.Weight;
            }
            return (float)Math.Round((decimal)(i / l.Count), 2);
        }

        public void setFamily(IList<Family> Families)
        {
            this.Families = null;
            Adults = new List<Adult>();
            Men = new List<Adult>();
            Women = new List<Adult>();


            this.Families = (List<Family>)Families;
            foreach(var f in this.Families)
            {
                foreach(var a in f.Adults)
                {
                    Adults.Add(a);
                }
            }
            foreach(var a in Adults)
            {
                if (a.Sex == "M" || a.Sex == "Male")
                    Men.Add(a);
                else if (a.Sex == "F" || a.Sex == "Female")
                    Women.Add(a);
            }
        }
    }
}
