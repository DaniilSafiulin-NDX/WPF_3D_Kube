using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Wpf3DRectangles.MyCode
{

    public class Rectangle3D : ModelVisual3D
    {

        #region Свойства управления прямоугольником

        private double _sizeX;
        public double SizeX
        {
            get => _sizeX;
            set
            {
                _sizeX = value;

                UpdateDate();
            }
        }

        private double _sizeY;
        public double SizeY
        {
            get => _sizeY;
            set
            {
                _sizeY = value;

                UpdateDate();
            }
        }


        private Point3D _pos;
        public Point3D Position
        {
            get => _pos;
            set
            {
                _pos = value;

                UpdateDate();
            }
        }


        // Материалы граней
        private Brush _front;
        public Brush Front
        {
            get => _front;
            set
            {
                _front = value;

                UpdateDate();
            }
        }

        private Brush _back;
        public Brush Back
        {
            get => _back;
            set
            {
                _back = value;

                UpdateDate();
            }
        }

        #endregion


        #region Создание 3D прямоугольника

        private void UpdateDate()
        {
            CreateMeshes3D(_sizeX, _sizeY, _pos, _front, _back);
        }


        private void CreateMeshes3D(double sizex, double sizey, Point3D pos, Brush front, Brush back)
        {
            Children.Clear();

            var left_bottom = new Point3D(-sizex / 2 + pos.X, -sizey / 2 + pos.Y, pos.Z);
            var right_bottom = new Point3D(sizex / 2 + pos.X, -sizey / 2 + pos.Y, pos.Z);
            var right_top = new Point3D(sizex / 2 + pos.X, sizey / 2 + pos.Y, pos.Z);
            var left_top = new Point3D(-sizex / 2 + pos.X, sizey / 2 + pos.Y, pos.Z);

            var meshGeometry3D = new MeshGeometry3D
            {
                Positions = new Point3DCollection
                {
                    left_bottom,
                    right_bottom,
                    right_top,
                    left_top,
                },
                TriangleIndices = new Int32Collection
                {
                    0, 1, 2,
                    0, 2, 3
                }
            };

            var model3D = new GeometryModel3D
            {
                Geometry = meshGeometry3D,
                Material = new DiffuseMaterial(front),
                BackMaterial = new DiffuseMaterial(back)
            };

            var visual3DMesh = new ModelVisual3D
            {
                Content = model3D
            };

            Children.Add(visual3DMesh);
        }

        #endregion
    }
}
