using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNPAssignment1.Data
{
    public interface IstatisticsService
    {
        int avgAge();
        int avgHeight();
        float avgWeight();
        string avgGender();

        string avgHair();

        string avgEye();
        string avgJob();

        void setFamily(IList<Family> Families);
    }
}
