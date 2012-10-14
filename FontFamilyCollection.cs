using System;
using System.Collections.Generic;
using System.Text;

namespace StyledControls
{
    public class FontFamilyCollection : System.Collections.CollectionBase{
        
        public System.Drawing.FontFamily this[int Index]{
            get { return (System.Drawing.FontFamily)List[Index]; }
        }

        public bool Contains(System.Drawing.FontFamily font_family){
            return List.Contains(font_family);
        }

        public int Add(System.Drawing.FontFamily font_family)
        {
            return List.Add(font_family);
        }

        public void Remove(System.Drawing.FontFamily font_family)
        {
            List.Remove(font_family);
        }

        public void Insert(int index, System.Drawing.FontFamily font_family)
        {
            List.Insert(index, font_family);
        }

        public int IndexOf(System.Drawing.FontFamily font_family)
        {
            return List.IndexOf(font_family);
        }
        public void AddRange(System.Drawing.FontFamily [] collection)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                this.Add(collection[i]);
            }
        }
        //public void AddRange(System.Drawing.FontFamily[] collection)
        //{
        //    this.AddRange(collection);
        //}

    }
}
