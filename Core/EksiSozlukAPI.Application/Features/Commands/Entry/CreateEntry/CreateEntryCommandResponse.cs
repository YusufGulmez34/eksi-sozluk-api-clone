﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry
{
    public class CreateEntryCommandResponse : Response
    {
        public CreateEntryCommandResponse(bool success, string message) : base(success, message)
        {
        }
    }

    public class SuccessCreateEntryCommandResponse : CreateEntryCommandResponse
    {
        public SuccessCreateEntryCommandResponse(string message) : base(true, message)
        {
        }
    }

    public class ErrorCreateEntryCommandResponse : CreateEntryCommandResponse
    {
        public ErrorCreateEntryCommandResponse(string message) : base(false, message)
        {
        }
    }
}
