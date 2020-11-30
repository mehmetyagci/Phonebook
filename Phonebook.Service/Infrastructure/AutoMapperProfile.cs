using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System;
using Phonebook.Domain;
using Phonebook.Dto;
using Phonebook.Constants;
using Phonebook.Domain.Base;

namespace Phonebook.Service.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            AllowNullDestinationValues = true;

            CreateMap<BaseEntity, BaseResponse>()
                .ReverseMap();

            #region Person

            CreateMap<Domain.Person, PersonResponse>()
                //.IncludeBase<BaseEntity, BaseResponse>()
                .ReverseMap();

            CreateMap<Domain.Person, CreatePersonRequest>()
                // .IncludeBase<BaseEntity, BaseResponse>()
                .ReverseMap();

            CreateMap<Domain.Person, UpdatePersonRequest>()
                // .IncludeBase<BaseEntity, BaseResponse>()
                .ReverseMap();

            CreateMap<Domain.Person, PersonDetailResponse>()
                // .IncludeBase<BaseEntity, BaseResponse>()
                .ReverseMap();

            #endregion Person

            #region CommunicationInfo

            CreateMap<Domain.CommunicationInfo, CommunicationInfoResponse>()
                 //.ForMember(destination => destination.CommunicationType,
                 //opt => opt.MapFrom(source => Enum.GetName(typeof(CommunicationType), source.CommunicationType)))
                 // .IncludeBase<BaseEntity, BaseResponse>()
                 .ReverseMap();

            CreateMap<Domain.CommunicationInfo, CreateCommunicationInfoRequest>()
                .ForMember(destination => destination.CommunicationType,
                           opt => opt.MapFrom(source => Enum.GetName(typeof(CommunicationType), source.CommunicationType)))
                // .IncludeBase<BaseEntity, BaseResponse>()
                .ReverseMap();

            #endregion CommunicationInfo

            #region Report
            CreateMap<Domain.Report, ReportResponse>()
                 // .IncludeBase<BaseEntity, BaseResponse>()
                 .ReverseMap();
            #endregion Report
        }
    }
}
