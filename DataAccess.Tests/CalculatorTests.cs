using System;
using System.Runtime.InteropServices;
using Xunit;

namespace DataAccess.Tests;
using DataAccess;

public class CalculatorTests
{
    [Fact]
    public void Subtract_ValuesShouldCalculate()
    {
        //Arrange
        double x = 5, y = 10;
        double expected = -5;
        //Note this is only testing that Subtract returns -5
        
        //Act
        double actual = Calculator.Subtract(x, y);
        
        //Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(5, 5, 10)]
    [InlineData(2, 3, 5)]
    [InlineData(double.MaxValue, 5, double.MaxValue)]
    [InlineData(double.NaN, double.NaN, double.NaN)]
    public void Add_ValuesShouldCalculate(double x, double y, double expected)
    {
        //Arrange
        
        //Act
        double actual = Calculator.Add(x, y);
        //Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(5, 5, 25)]
    [InlineData(2, -3, -6)]
    [InlineData(double.PositiveInfinity, -1, double.NegativeInfinity)]
    [InlineData(double.NaN, double.NaN, double.NaN)]
    public void Multiply_ValuesShouldCalculate(double x, double y, double expected)
    {
        //Arrange
        
        //Act
        double actual = Calculator.Multiply(x, y);
        //Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(5, -5, -1)]
    [InlineData(10, 20, .5)]
    [InlineData(5, double.NegativeInfinity, 0)]
    [InlineData(double.NaN, double.NaN, double.NaN)]
    public void Divide_SimpleValuesShouldCalculate(double x, double y, double expected)
    {
        //Arrange
        
        //Act
        double actual = Calculator.Divide(x, y);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Divide_ShouldThrow_WhenYIsZero()
    {
        //Arrange
        double x = 5;
        double y = 0;
        
        //Act
        
        //Assert
        //note normally dividing by zero returns double.PositiveInfinity
        //throwing is specific to my Calculator.Divide
        Assert.Throws<DivideByZeroException>(() =>Calculator.Divide(x, y));
    }
}