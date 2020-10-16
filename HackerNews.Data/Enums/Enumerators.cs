using System;
using System.ComponentModel;
using System.Reflection;

namespace HackerNews.Data.Enums
{
    public enum EndpointType: byte
    {
        [Description("newstories")]
        NewStories = 0,

        [Description("beststories")]
        BestStories = 1,

        [Description("topstories")]
        TopStories = 2,

        [Description("showstories")]
        ShowStories = 3,

        [Description("askstories")]
        AskStories = 4,

        [Description("jobstories")]
        JobStories = 5
    }

    public enum StoryType: byte
    {
        [Description("story")]
        Story = 0,

        [Description("ask")]
        Ask = 1,

        [Description("job")]
        Job = 2,

        [Description("comment")]
        Comment = 3,

        [Description("poll")]
        Poll = 4,

        [Description("pollopt")]
        PollOption = 5,
    }

    public enum StatusCode : byte {
        Success = 0,
        NotFound = 1,
        BadRequest = 2,
        GenericError = 3,
        Unauthorized = 4,
        Forbidden = 5,
        Conflict = 6,
        Warning = 7,
    }

    public static class ExtensionMethods
    {
        public static string ToDescription(this Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return en.ToString();
        }

        public static string FromDescription(this Enum en, string description)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0 && ((DescriptionAttribute)attrs[0]).Description.ToLowerInvariant().Equals(description))
                    return "test";
                    //return en;
            }

            return "";
        }
    }
}
