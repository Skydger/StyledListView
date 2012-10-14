using System;
using System.Collections.Generic;
using System.Text;

namespace StyledControls
{
    public sealed class Style{
        private System.Drawing.Color bg_color;
        private System.Drawing.Color fg_color;
        //private System.Drawing.FontFamily ffamily;
        private System.Drawing.Font font;
        private StyledControls.FontFamilyCollection ffamilies;
        public System.Drawing.Color BackgroundColor{
            get { return this.bg_color; }
            set { this.bg_color = value; }
        }
        public System.Drawing.Color ForegroundColor{
            get { return this.fg_color; }
            set { this.fg_color = value; }
        }
        public System.Drawing.Font Font{
            get { return this.font; }
            set { this.font = value; }
        }
        //[System.ComponentModel.Category("Behavior")]
        //System.ComponentModel.
        [System.ComponentModel.DefaultValue("Times New Roman")]
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
//        		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        public StyledControls.FontFamilyCollection FontFamily{
            get { return this.ffamilies; }
            set { this.ffamilies = value; }
        }

        public Style(){
            this.bg_color = System.Drawing.Color.White;
            this.fg_color = System.Drawing.Color.Gray;
            this.ffamilies = new FontFamilyCollection();
            System.Drawing.Text.InstalledFontCollection ifc = new System.Drawing.Text.InstalledFontCollection();
            foreach( System.Drawing.FontFamily ff in ifc.Families ){
                this.ffamilies.Add(ff);
            }
        }
    }
    
    public class StylesCollection : System.Collections.CollectionBase{
        
        public Style this[int Index]{
            get { return (Style)List[Index]; }
        }

        public bool Contains(Style style){
            return List.Contains(style);
        }

        public int Add(Style style){
            return List.Add(style);
        }

        public void Remove(Style style){
            List.Remove(style);
        }

        public void Insert(int index, Style style){
            List.Insert(index, style);
        }

        public int IndexOf(Style style){
            return List.IndexOf(style);
        }
    }
}
