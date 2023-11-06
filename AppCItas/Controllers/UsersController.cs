﻿using AppCitas.Controllers;
using AppCitas.DTOs;
using AppCitas.Interfaces;
using AppCItas.Data;
using AppCItas.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppCItas.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UsersController(IUserRepository userRepository, IMapper mapper ) 
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>>GetUsers() 
    {
        var users = await _userRepository.GetMembersAsync();

        return Ok(users);
    }

    
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        return await _userRepository.GetMemberAsync(username);

    }
}
