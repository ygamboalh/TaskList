using AutoMapper;
using Moq;
using System;
using System.Runtime.Serialization;
using TaskListWebApi.Dtos;
using TaskListWebApi.Mapper;
using TaskListWebApi.Models;
using Xunit;

namespace TaskListTests.Mapper
{
    public class AutoMapperProfilesTests
    {
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configuration;

        public AutoMapperProfilesTests()
        {
            _configuration = new MapperConfiguration(cfg => 
            {
                cfg.AddProfile<AutoMapperProfiles>(); 
            });
            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void Should_Be_AValid_Configuration()
        {
            //Assert
            _configuration.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(TaskCreateDto), typeof(TaskList))]
        public void Map_The_Source_ToDestination_Exist_Configuration(Type origin, Type destination) 
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _mapper.Map(instance, origin, destination);
        }
    }
}
