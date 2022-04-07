using AutoMapper;
using Project_API_2021.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_API_2021.Extra.DTO
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<FactionDTO, Faction>();
                
        }
    }
}
