using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Entity
{
    public class Tasks
    {
        public int TasksId { get; set; }

        [Required(ErrorMessage = "Lütfen Başlık Alanını Doldurunuz.")]
        [StringLength(30,ErrorMessage ="Lütfen En Fazla 30 Karakterlik Başlık Oluşturunuz.")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Lütfen İçerik Alanını Doldurunuz.")]
        [StringLength(180, ErrorMessage = "Lütfen En fazla 180 Karakterlik İçerik Oluşturunuz.")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Lütfen Tarih Belirtiniz.")]
        public DateTime TaskDate { get; set; }
    }
}
