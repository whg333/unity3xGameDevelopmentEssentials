# unity3xGameDevelopmentEssentials
本项目是书籍[《Unity 3.x游戏开发经典教程》](http://book.douban.com/subject/22925700/)（英文版[《Unity 3.x Game Development Essentials》](http://www.amazon.com/Unity-3-x-Game-Development-Essentials/dp/1849691444/ref=sr_1_1?ie=UTF8&qid=1450686270&sr=8-1&keywords=Unity+3.x+Game+Development+Essentials)）的例子。
![ch_v](./images/book_ch.jpg)

![en_v](./images/book_en.png)

其中按照chapter做区分了，每个chapter作为单独的Unity项目，可使用Unity单独打开每个chapter文件；因为使用的[Unity](http://unity3d.com/cn/get-unity/download/archive)版本是[5.3.0](http://unity3d.com/cn/unity/whats-new/unity-5.3)，所以对于3.x版本中已经过期的API使用了5.3.0的新API做替换了（其实Unity编辑器会自动检测C#脚本，如果发现使用过时API的话，会提示是否尝试自动修复，**但不敢确保修复的正确性，最好先备份！**）

## chapter02
![ch02](./images/chapter02.png)

## chapter03
![ch03](./images/chapter03.png)

## chapter05
![ch05](./images/chapter05.png)

## chapter06
![ch06](./images/chapter06.png)

![ch06_1](./images/chapter06_1.png)

![ch06_2](./images/chapter06_2.png)

### 遇到的问题
#### GUITexture在第一人称视角下不能正常显示

**问题：**发现添加的GUITexture根本不能显示，即在第一人称视角摄像机中不能显示

**解决：**起初也没找到原因，以为是不是Unit5版本想替换掉GUITexture等老的GUI而转去NGUI？然后各种尝试，在编辑器下面创建了画板（Canvas），并添加原画组件（RawImage）就可以显示了，于是乎把UI组件都使用Canvas+RawImage的方式重新组织了一下，并写了个UIManager控制GUI组件的显示/隐藏；但是在chapter09的时候却发现是可以显示GUITexture的，唯一不同的地方是摄像机，一个是FPSController子组件下的，一个是我们自己创建的，比较了一下发现原来是**Unity5版本的FPSController下的摄像机Camera组件默认是缺少GUILayer的，从而导致不能显示GUITexture！**添加上GUILayer就可以了。而且需要注意的是GUITexture位置的x和y值范围必须在0到1之间！

## chapter07
![ch07](./images/chapter07.png)

![ch07_1](./images/chapter07_1.png)

![ch07_2](./images/chapter07_2.png)

## chapter08
![ch08](./images/chapter08.png)

![cha08_1](./images/chapter08_1.png)

## chapter09
![chap09](./images/chapter09.png)

![chap09_1](./images/chapter09_1.png)

### 遇到的问题
#### 切换场景后天空盒反射光无效导致画面黑暗
**问题：**因为本章涉及到切换场景功能，所以发现从Menu主菜单场景切换到游戏IsLand场景，明显画面变黑，材质变黑了，搜索了一番，发现应是**Unity5版本有天空盒光效自动渲染的过程**，所以你会发现之前有天空盒的chapter中，刚进入Unity加载时画面最初也是偏黑的，过一会天空盒反射光效渲染完毕后才慢慢明亮起来

**解决：**暂时尚未解决。。。有猜想过是不是可以使用脚本写代码控制天空盒的反射光效，等到天空盒反射光效渲染完毕后才切换至IsLand场景，但控制天空盒反射光效的代码需要深入了解Unity5的支持了，或者有没有其他办法解决这个问题呢？

[unity3d贴吧里也有询问的](http://tieba.baidu.com/p/4046051118)，貌似说只是在编辑器切换场景会出现该种情况，而在实际build打包出来的程序是不会有此问题，那这倒好了，最后build打包的时候再验证一下了

**最终验证了！确实只是Unity编辑器的问题，真正打包后会把天空盒反射光效都考虑进去了！**

## chapter10
![chap10](./images/chapter10.png)

![chap10_1](./images/chapter10_1.png)

![chap10_2](./images/chapter10_2.png)

![chap10_3](./images/chapter10_3.png)

## chapter11
红色标记是第一人称出生点，可隐隐约约看到从红色出生点到蓝色房屋有石头小径。
![chap11](./images/chapter11.png)

房屋内的灯光光效制作
![chap11_1](./images/chapter11_1.png)

![chap11_2](./images/chapter11_2.png)

![chap11_3](./images/chapter11_3.png)

![chap11_4](./images/chapter11_4.png)

火山烟雾粒子系统
![chap11_5](./images/chapter11_5.png)

扔椰子划痕效果
![chap11_6](./images/chapter11_6.png)

余下就是一些运行游戏后在岛屿上的观光图了
![chap11_7](./images/chapter11_7.png)

![chap11_8](./images/chapter11_8.png)

![chap11_9](./images/chapter11_9.png)

![chap11_10](./images/chapter11_10.png)

![chap11_11](./images/chapter11_11.png)

![chap11_12](./images/chapter11_12.png)

![chap11_13](./images/chapter11_13.png)

最后是在房屋内获得火柴后出去点燃火把结束游戏
![chap11_14](./images/chapter11_14.png)

![chap11_15](./images/chapter11_15.png)

## chapter12
终于轮到发布了。。。这里由于只安装了Unity编辑器，平台支持暂未安装，所以只能先发布WebPlayer版本的，Windows单机版和Android版的之后补上。照着书籍上的设置下Project Settings
![chap12](./images/chapter12.png)

点击build按钮后选择文件夹，过一会便会生成build.html和build.unity3d文件，至于名称为什么是build前缀开头是因为选择了名字为build目录打包的。**（注意在build的时候如果编译错误，则这2个文件都不会生成，注意查看console错误信息）**

![chap12_1](./images/chapter12_1.png)

build.html就是正常的html文件，JQuery简直是Web JS开发必备了。。。
![chap12_2](./images/chapter12_2.png)

build构建打包完毕后可直接使用本地浏览器打开该build.html
![chap12_3](./images/chapter12_3.png)

为了便于快速跑遍整个岛屿，设置**FPSController的Walk Speed为10**，截了跳到屋顶上的图
![chap12_4](./images/chapter12_4.png)

如果浏览器不支持则页面会提示（自己的Chrome浏览器就由于某种原因不支持，但是FireFox却可以）
![chap12_5](./images/chapter12_5.png)

**除了本地浏览器直接打开外，也可放到服务器上，这里直接把生成的build.html和build.unity3d文件放到自己的GitHub上了**，具体链接地址如下，大家可以亲自体验下：

[《Unity 3.x Game Development Essentials》 example for Unity 5.3.0](http://www.iclojure.com/unity3d/build.html)

### 多平台支持
Windows版和Android版的需要安装相应的支持，如下是下载的多平台支持的安装文件

![chap12_jpg](./images/chapter12.jpg)

或者直接使用Unity安装助手安装的时候选择支持的平台

![chap12_6](./images/chapter12_6.png)

有了多平台支持后，配置下Player Settings就可以build了，例如截图的是Windows平台64位的
![chap12_9](./images/chapter12_9.png)

Windows平台build完成后会生成exe执行文件

![chap12_8](./images/chapter12_8.png)

然后运行该exe文件，因为配置Player Settings时允许弹出游戏设置框，所以可看到如下设置框界面

![chap12_7](./images/chapter12_7.png)

然后直接点击Play按钮进入游戏，可看到Unity Logo加载界面和后续的游戏运行图了
![chap12_10](./images/chapter12_10.png)

![chap12_11](./images/chapter12_11.png)

![chap12_12](./images/chapter12_12.png)
