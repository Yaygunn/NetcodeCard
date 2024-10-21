namespace Yaygun
{
	public class Character 
	{
		public int MaxHealth { get; } = 10;
		public int Health { get; private set; }

		public Character()
		{
			Health = MaxHealth;
		}

		public float GiveDamage(int damage)
		{
			Health -= damage;
			if(Health < 0)
				Health = 0;

			return (float)Health/MaxHealth;
		}

	}
}
