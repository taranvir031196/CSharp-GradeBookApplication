﻿using System;
using System.Linq;
using Xunit;

using GradeBook;
using GradeBook.Enums;
using System.Collections.Generic;

namespace GradeBookTests
{
    public class GradeBookTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook",true);
            Assert.True(gradeBook.Name == "Test GradeBook");
            Assert.True(gradeBook.Students != null);
        }

        [Fact]
        public void AddStudentTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook",true);
            var student = new Student("Test Student",StudentType.Standard,EnrollmentType.Campus);
            gradeBook.AddStudent(student);
            Assert.True(gradeBook.Students.Count == 1);
            Assert.True(gradeBook.Students[0] == student);
        }

        [Fact]
        public void AddStudentThrowsExceptionOnEmptyNameTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook",true);
            var student = new Student(string.Empty, StudentType.Standard, EnrollmentType.Campus);
            Assert.Throws(typeof(ArgumentException),() => gradeBook.AddStudent(student));
        }

        [Fact]
        public void RemoveStudentTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook",true);
            gradeBook.Students.Add(new Student("johnson", StudentType.Standard, EnrollmentType.Campus));
            gradeBook.Students.Add(new Student("jamie", StudentType.Standard, EnrollmentType.Campus));
            gradeBook.RemoveStudent("jamie");
            Assert.True(gradeBook.Students.FirstOrDefault(e => e.Name == "jamie") == null);
        }

        [Fact]
        public void RemoveStudentThrowsExceptionOnEmptyNameTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook", true);
            gradeBook.Students.Add(new Student("jamie", StudentType.Standard, EnrollmentType.Campus));
            Assert.Throws(typeof(ArgumentException), () => gradeBook.RemoveStudent(string.Empty));
        }

        [Fact]
        public void RemoveStudentStudentNotFoundTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook",true);
            gradeBook.Students.Add(new Student("jamie", StudentType.Standard, EnrollmentType.Campus));
            gradeBook.RemoveStudent("robert");
        }

        [Fact]
        public void AddGradeTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook", true);
            gradeBook.Students.Add(new Student("jamie", StudentType.Standard, EnrollmentType.Campus));
            gradeBook.AddGrade("jamie",100);
            Assert.True(gradeBook.Students.FirstOrDefault(e => e.Name == "jamie").Grades.Count == 1);
            Assert.True(gradeBook.Students.FirstOrDefault(e => e.Name == "jamie").Grades[0] == 100);
        }

        [Fact]
        public void AddGradeThrowsExceptionOnEmptyNameTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook", true);
            Assert.Throws(typeof(ArgumentException), () => gradeBook.AddGrade(string.Empty,100));
        }

        [Fact]
        public void AddGradeTestNotFoundTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook", true);
            gradeBook.AddGrade("jamie", 100);
        }

        [Fact]
        public void RemoveGradeTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook", true);
            gradeBook.Students.Add(new Student("jamie", StudentType.Standard, EnrollmentType.Campus));
            gradeBook.Students.FirstOrDefault(e => e.Name == "jamie").Grades = new List<double> { 100, 50 };
            gradeBook.RemoveGrade("jamie", 100);
            Assert.True(gradeBook.Students.FirstOrDefault(e => e.Name == "jamie").Grades.Count == 1);
            Assert.True(gradeBook.Students.FirstOrDefault(e => e.Name == "jamie").Grades[0] == 50);
        }

        [Fact]
        public void RemoveGradeStudentNotFoundTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook", true);
            gradeBook.Students.Add(new Student("jamie", StudentType.Standard, EnrollmentType.Campus));
            gradeBook.Students.FirstOrDefault(e => e.Name == "jamie").Grades = new List<double> { 100, 50 };
            gradeBook.RemoveGrade("bob", 100);
        }

        [Fact]
        public void RemoveGradeThrowsExceptionOnEmptyNameTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook", true);
            Assert.Throws(typeof(ArgumentException), () => gradeBook.RemoveGrade(string.Empty, 100));
        }
    }
}
