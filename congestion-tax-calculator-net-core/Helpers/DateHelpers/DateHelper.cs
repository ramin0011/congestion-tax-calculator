﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace congestion.calculator.Helpers.DateHelpers
{
    internal static class DateHelper
    {
        public static Dictionary<DateTime, List<DateTime>> GroupByCloseDates(this DateTime[] dates, int interval_minutes)
        {
            return GroupByCloseDates(dates.ToList(), interval_minutes);
        }
        public static Dictionary<DateTime, List<DateTime>> GroupByCloseDates(this List<DateTime> dates,int interval_minutes)
        {
            var result=new Dictionary<DateTime,List<DateTime>>();

            dates = dates.OrderBy(a=>a).ToList();
            for (int i = 0; i < dates.Count; i++)
            {
                DateTime date = dates[i];
                
                List<DateTime> list = new List<DateTime>();
                for (int j = i+1; j < dates.Count; j++)
                {
                    if (j== dates.Count-1)
                    {
                        break;
                    }
                    if (Math.Abs((date - dates[j]).TotalMinutes) <= interval_minutes)
                    {
                        list.Add(dates[j]);
                        i++;
                    }
                    else if (!list.Any())
                    {
                        list.Add(date);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }


                if(list.Any())
                    result.Add(date,list);
            }

            return result;
        }
    }
}
