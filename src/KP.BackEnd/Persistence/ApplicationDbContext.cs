﻿using System;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        private DbSet<Card> _cards;
        private DbSet<Course> _courses;
        private DbSet<Comment> _comments;
        private DbSet<Student> _students;
        private DbSet<Supervisor> _supervisors;

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new SupervisorConfiguration());
            builder.ApplyConfiguration(new CardConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
        }

        public DbSet<Course> Courses
        {
            get => _courses;
            set => _courses = value;
        }

        public DbSet<Card> Cards 
        {
            get => _cards;
            set => _cards = value;
        }

        public DbSet<Comment> Comments 
        {
            get => _comments;
            set => _comments = value;
        }

        public DbSet<Student> Students 
        {
            get => _students;
            set => _students = value;
        }

        public DbSet<Supervisor> Supervisors
        {
            get => _supervisors;
            set => _supervisors = value;
        }
    }
}
