using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System;
using Phonebook.Domain;
using Phonebook.Dto;
using Phonebook.Constants;

namespace Phonebook.Service.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            AllowNullDestinationValues = true;

            #region Person

            CreateMap<Domain.Person, PersonResponse>().ReverseMap();

            CreateMap<Domain.Person, CreatePersonRequest>().ReverseMap();

            CreateMap<Domain.Person, UpdatePersonRequest>().ReverseMap();

            CreateMap<Domain.Person, PersonDetailResponse>();

            #endregion Person

            #region CommunicationInfo

            CreateMap<Domain.CommunicationInfo, CommunicationInfoResponse>()
                 //.ForMember(destination => destination.CommunicationType,
                 //opt => opt.MapFrom(source => Enum.GetName(typeof(CommunicationType), source.CommunicationType)))
                 .ReverseMap();

            CreateMap<Domain.CommunicationInfo, CreateCommunicationInfoRequest>()
                .ForMember(destination => destination.CommunicationType,
                 opt => opt.MapFrom(source => Enum.GetName(typeof(CommunicationType), source.CommunicationType)))
                .ReverseMap();

            #endregion CommunicationInfo
        }
    }
}
