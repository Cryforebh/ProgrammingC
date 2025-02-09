using GamePrototype.Combat;
using GamePrototype.Dungeon;

namespace GamePrototype.Items
{

    struct RockPaperScissorsName
    {
        public string Name(RockPaperScissors rockPaperScissors)
        {
            switch (rockPaperScissors)
            {
                case RockPaperScissors.Rock:
                    return "Камень";
                case RockPaperScissors.Paper:
                    return "Бумага";
                case RockPaperScissors.Scissors:
                    return "Ножницы";
                default:
                    return "Ошибка перевода";
            }

        }
    }

    struct DirectionName
    {
        public string Name(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return "Налево";
                case Direction.Forward:
                    return "Прямо";
                case Direction.Right:
                    return "Направо";
                default:
                    return "Ошибка перевода";
            }
        }
    }
}
