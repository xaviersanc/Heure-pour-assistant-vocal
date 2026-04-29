public class Gladiator(string name, int health, int strength, int armor) {
    public string Name { get; } = name;
    public int Health { get; private set; } = health;
    public int Strength { get; private set; } = strength;
    public int Armor { get; private set; } = armor;

    public void Attack(Gladiator opponent, IDice dice) {
        var score = dice.Roll();
        throw new NotImplementedException("To be done");
    }
}

public interface IDice {
    int Roll();
}

public class Dice(int faces) : IDice {
    private readonly Random rnd = new ();

    public int Roll() => rnd.Next(1, faces + 1);
}