using System;

namespace IotRemoteLaboratory.Models
{
	public class User
	{
		private static Random _random = new Random();

		public string Name { get; }

		public User()
		{
			Name = GenerateNickname();
		}

		private static string GenerateNickname()
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, 10).Select(s => s[_random.Next(s.Length)]).ToArray());
		}

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Name == ((User)obj).Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
