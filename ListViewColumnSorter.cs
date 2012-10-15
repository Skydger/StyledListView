using System;
using System.Collections.Generic;
using System.Text;

namespace StyledControls
{
    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class ListViewColumnSorter : System.Collections.IComparer{
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private System.Windows.Forms.SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private System.Collections.CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            this.ColumnToSort = 0;

            // Initialize the sort order to 'none'
            this.OrderOfSort = System.Windows.Forms.SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            this.ObjectCompare = new System.Collections.CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y){
            int compareResult;
            System.Windows.Forms.ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (System.Windows.Forms.ListViewItem)x;
            listviewY = (System.Windows.Forms.ListViewItem)y;

            if (listviewX.Group == listviewY.Group){

                // Сравнение значений
                int ix = 0, iy = 0;
                string l1s = "0";
                string l2s = "0";
                if (listviewX.SubItems.Count > ColumnToSort) l1s = (string)listviewX.SubItems[ColumnToSort];
                if (listviewY.SubItems.Count > ColumnToSort) l2s = (string)listviewY.SubItems[ColumnToSort];
                if (System.Int32.TryParse(l1s, out ix) &&
                    System.Int32.TryParse(l2s, out iy))
                {
                    compareResult = ix - iy;
                }else{
                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
                }

                // Calculate correct return value based on object comparison
                if (OrderOfSort == System.Windows.Forms.SortOrder.Ascending){
                    // do nothing
                }
                else if (OrderOfSort == System.Windows.Forms.SortOrder.Descending){
                    // Descending sort is selected, return negative result of compare operation
                    compareResult = -compareResult;
                }else{
                    // Return '0' to indicate they are equal
                    compareResult = 0;
                }
            }else{
                compareResult = 0;
            }
            return compareResult;
        }
        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn{
            set{
                ColumnToSort = value;
            }get{
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public System.Windows.Forms.SortOrder Order{
            set{
                OrderOfSort = value;
            }get{
                return OrderOfSort;
            }
        }

    }

}
