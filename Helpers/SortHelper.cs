using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegratedUniversityInformationSystem.Helpers
{
    public static class SortHelper
    {
        // reusable sort method for any form
        public static List<T> SortList<T>(
            List<T> sourceList,
            string sortColumn,
            string sortOrder,
            DataGridView dgv,
            Func<T, string> getStudentName = null)
        {
            if (sourceList == null || sourceList.Count == 0)
                return sourceList;

            bool isAscending = sortOrder == "Ascending";

            // sort using switch on column name
            switch (sortColumn)
            {
                case "ID":
                    return isAscending ? sourceList.OrderBy(x => GetPropertyValue(x, "Id")).ToList()
                                       : sourceList.OrderByDescending(x => GetPropertyValue(x, "Id")).ToList();

                case "Student":
                    if (getStudentName != null)
                        return isAscending ? sourceList.OrderBy(x => getStudentName(x)).ToList()
                                           : sourceList.OrderByDescending(x => getStudentName(x)).ToList();
                    break;

                default:
                    return isAscending ? sourceList.OrderBy(x => GetPropertyValue(x, sortColumn)).ToList()
                                       : sourceList.OrderByDescending(x => GetPropertyValue(x, sortColumn)).ToList();
            }

            return sourceList;
        }

        // gets property value using reflection
        private static object GetPropertyValue<T>(T obj, string propertyName)
        {
            var prop = typeof(T).GetProperty(propertyName);
            return prop != null ? prop.GetValue(obj) : null;
        }

        // loads sort column dropdown
        public static void LoadSortColumns(ComboBox cmb, string[] columns)
        {
            cmb.Items.Clear();
            foreach (var col in columns)
                cmb.Items.Add(col);
            cmb.SelectedIndex = 0;
        }

        // loads sort order dropdown
        public static void LoadSortOrders(ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.Items.Add("Ascending");
            cmb.Items.Add("Descending");
            cmb.SelectedIndex = 0;
        }
    }
}
