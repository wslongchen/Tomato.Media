﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Catel.Data;
using Tomato.Tools.Common.Gaming;

namespace Tomato.TileSetEditor.Models
{
    class ExtraImagesEditorModel : ModelBase
    {
        private readonly TileSetModel _tileSet;

        private ObservableCollection<ExtraImageModel> _extraImages;
        public IReadOnlyCollection<ExtraImageModel> ExtraImages
        {
            get { return _extraImages; }
        }

        public ExtraImagesEditorModel(TileSetModel tileSet, BitmapSource extraImage)
        {
            _tileSet = tileSet;
            _extraImages = new ObservableCollection<ExtraImageModel>(_tileSet.TileSet.ExtraImages.Select((e, i) =>
                new ExtraImageModel(i, e, LoadImageFromExtraImage(e, extraImage))));
            RaisePropertyChanged(nameof(ExtraImages));
            _extraImages.CollectionChanged += _extraImages_CollectionChanged;
        }

        public void AddExtraImage(BitmapSource image)
        {
            _extraImages.Add(new ExtraImageModel(_extraImages.Count, new ExtraImage()
            {
                Width = image.PixelWidth,
                Height = image.PixelHeight
            }, image));
        }

        private void _extraImages_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (ExtraImageModel item in e.NewItems)
                        _tileSet.TileSet.ExtraImages.Add(item.ExtraImage);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (ExtraImageModel item in e.OldItems)
                        _tileSet.TileSet.ExtraImages.Remove(item.ExtraImage);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    _tileSet.TileSet.ExtraImages.Clear();
                    foreach (var item in _extraImages)
                        _tileSet.TileSet.ExtraImages.Add(item.ExtraImage);
                    break;
            }
        }

        public BitmapSource LoadImageFromExtraImage(ExtraImage item, BitmapSource extraImage)
        {
            var image = new WriteableBitmap(item.Width, item.Height, 96, 96, PixelFormats.Pbgra32, null);
            var rect = new Int32Rect(item.X, item.Y, item.Width, item.Height);
            image.Lock();
            extraImage.CopyPixels(rect, image.BackBuffer, image.BackBufferStride * image.PixelHeight, image.BackBufferStride);
            image.Unlock();
            image.Freeze();
            return image;
        }
    }
}
