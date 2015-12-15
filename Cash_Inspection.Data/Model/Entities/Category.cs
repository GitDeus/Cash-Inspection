using Cash_Inspection.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Inspection.Data.Model.Entities
{
    public class Category
    {
        private User _user;
        private ICollection<Subcategory> _subcategories;
        [Required]
        public Guid Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Название категории")]
        [StringLength(36, ErrorMessage = "{0} не должно превышать {1} символов")]
        public string Title { get; set; }



        [Required]
        [Display(Name = "Лимит стредств")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Range(0, int.MaxValue, ErrorMessage = "Поле {0} должно быть больше {1} и менее {2}")]
        public decimal NumberofMoney { get; set; }
        public virtual ICollection<Subcategory> Subcategories
        {
            get { return _subcategories ?? (_subcategories = new List<Subcategory>()); }
            set { _subcategories = value; }
        }

        public virtual Guid UserId { get; set; }
        public virtual User User {
            get { return _user; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _user = value;
            }
        }
    }
    public class Subcategory
    {
        private Category _category;
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Содержание")]
        [DataType(DataType.MultilineText)]
        [StringLength(36)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Стоимость")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Range(0, int.MaxValue, ErrorMessage = "Поле {0} должно быть больше {1} и менее {2}")]
        public decimal Value { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public virtual Guid CategoryId { get; set; }
        public virtual Category Category {
            get { return _category; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _category = value;
            }
        }
    }
    
}
