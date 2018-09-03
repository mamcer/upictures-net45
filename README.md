# UPictures

A .NET MVC Web Application and console application from 2016.

> More details about why I published this project in [this blog post](https://mamcer.github.io/2018-09-02-i-cleaned-up-my-virtual-basement/)

## Description

An web application that helps to easily search, tag and view pictures and videos from a media collection.

It recursively scan a directory looking for pictures and videos. Creating thumbnails for both and low resolution images for search, thumbnail and view. It also creates a low resolution version of the video, to improve playing performance.

I later take this project (and rewrite it) to play with .NET Core.

## Technologies

- Visual Studio 2015
- Entity Framework 6.1
- SQL Server 2014

It also uses [ffmpeg](https://www.ffmpeg.org/) and [irfanview](https://www.irfanview.com/) to create thumbnails and low resolution version of images and videos.
