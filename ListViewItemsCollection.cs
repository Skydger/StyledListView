using System;
using System.Collections.Generic;
using System.Text;

namespace StyledControls
{
/*    
    public class ListViewItemsCollection : System.Collections.CollectionBase{

        private StyledControls.NewItemAdded newAdded = null;

        public ListViewItemsCollection(StyledControls.NewItemAdded OnNewAdded){
            this.newAdded = OnNewAdded;
        }
        public System.Windows.Forms.ListViewItem this[int Index]
        {
            get { return (System.Windows.Forms.ListViewItem)List[Index]; }
        }

        public bool Contains(System.Windows.Forms.ListViewItem list_view_item)
        {
            return List.Contains(list_view_item);
        }

        public int Add(System.Windows.Forms.ListViewItem list_view_item)
        {
            int index = List.Add(list_view_item);
            if (this.newAdded != null) newAdded.Invoke(index, list_view_item);
            return index;
        }

        public void Remove(System.Windows.Forms.ListViewItem list_view_item)
        {
            List.Remove(list_view_item);
        }

        public void Insert(int index, System.Windows.Forms.ListViewItem list_view_item)
        {
            List.Insert(index, list_view_item);
        }

        public int IndexOf(System.Windows.Forms.ListViewItem list_view_item)
        {
            return List.IndexOf(list_view_item);
        }
        public void AddRange(ListViewItemsCollection collection){
            for (int i = 0; i < collection.Count; i++){
                this.Add(collection[i]);
            }     
        }
        public void AddRange(ListViewItemsCollection[] collection){
            this.AddRange(collection);     
        }
        public void AddRange(System.Windows.Forms.ListViewItem [] collection){
            for (int i = 0; i < collection.Length; i++)
            {
                this.Add(collection[i]);
            }
        }
    }*/
    public class ListViewItemsCollection : System.Windows.Forms.ListView.ListViewItemCollection{
        private StyledControls.NewItemAdded newAdded = null;

        public ListViewItemsCollection(System.Windows.Forms.ListView owner, StyledControls.NewItemAdded OnNewAdded)
            : base(owner)
        {
            this.newAdded = OnNewAdded;
        }
        public override System.Windows.Forms.ListViewItem Add(System.Windows.Forms.ListViewItem list_view_item){
            System.Windows.Forms.ListViewItem new_item = base.Add(list_view_item);
            //int index = List.Add(list_view_item);
            if (this.newAdded != null) newAdded.Invoke(new_item.Index, new_item);
            return new_item;
        }

    }
}
