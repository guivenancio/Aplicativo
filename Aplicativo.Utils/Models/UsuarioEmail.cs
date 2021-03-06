﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicativo.Utils.Models
{

    [Serializable()]
    [Table("UsuarioEmail")]
    public partial class UsuarioEmail : _Extends
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? UsuarioEmailID { get; set; }

        [ForeignKey("Usuario")]
        public int? UsuarioID { get; set; }

        [StringLength(200)]
        public string Smtp { get; set; }

        public int? Porta { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(40)]
        public string Senha { get; set; }

        public bool? Ssl { get; set; }

        public string Ssl_Habilitado => (Ssl ?? false) ? "Sim" : "Não";

        public virtual Usuario Usuario { get; set; }

    }
}