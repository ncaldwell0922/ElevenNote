using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ElevenNote.Services.Note
{
    public class NoteService : INoteService
    {
        private readonly int _userId;
        public NoteService(IHttpContextAccessor httpContextAccessor)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            if (!validId)
                throw new Exception("Attempted tp build NoteService without User Id claim.");
        }
    }
}