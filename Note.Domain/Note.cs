﻿using System;

namespace Note.Domain
{
    public class Note
    {
        public Guid UserId { get; set; }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? EditeTime { get; set; }
    }
}