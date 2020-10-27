using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNPAssignment1.Data
{
    public interface IstatisticsService
    {
        int avgAge(string str);
        int avgHeight(string str);
        float avgWeight(string str);
        string avgGender(string str);

        string avgHair(string str);

        string avgEye(string str);
        string avgJob(string str);

        void setFamily(IList<Family> Families);
    }
}
