//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektSemestralny.MVVM.Model
{
    using ProjektSemestralny.Core;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public partial class player : ObservableObject
    {
        private string player_name1;
        private int player_id1;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public player()
        {
            this.characters = new ObservableCollection<character>();
        }

        public int player_id 
        { 
            get => player_id1;
            set
            {
                player_id1 = value;
                OnPropertyChanged();
            }
        }
        public string player_name
        {
            get => player_name1;
            set
            {
                player_name1 = value;
                OnPropertyChanged();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<character> characters { get; set; }
    }
}
