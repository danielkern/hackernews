using HackerNews.Data;
using NUnit.Framework;
using System;

namespace Tests
{
    public class StoryTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldConvertTimestampToDateCorrectly()
        {
            Story story = new Story
            {
                Time = 1602650000
            };
            DateTime expectedDate = new DateTime(2020, 10, 14, 4, 33, 20);
            Assert.AreEqual(story.Date, expectedDate);
        }
    }
}
