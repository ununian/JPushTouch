using System;
using Foundation;
using ObjCRuntime;
using CoreLocation;
using UIKit;

namespace JPush
{
    partial interface JPushConstants
    {
        // extern NSString *const kJPFNetworkDidSetupNotification;
        /// <summary>
        /// 建立连接
        /// </summary>
        /// <value>The k JPF network did setup notification.</value>
        [Field("kJPFNetworkDidSetupNotification")] 
        NSString kJPFNetworkDidSetupNotification { get; }



        // extern NSString *const kJPFNetworkDidCloseNotification;
        /// <summary>
        /// 关闭连接
        /// </summary> 
        [Field("kJPFNetworkDidCloseNotification")]
        NSString kJPFNetworkDidCloseNotification { get; }

        // extern NSString *const kJPFNetworkDidRegisterNotification;
        /// <summary>
        /// 注册成功
        /// </summary> 
        [Field("kJPFNetworkDidRegisterNotification")]
        NSString kJPFNetworkDidRegisterNotification { get; }

        // extern NSString *const kJPFNetworkDidLoginNotification;
        /// <summary>
        /// 登录成功
        /// </summary> 
        [Field("kJPFNetworkDidLoginNotification")]
        NSString kJPFNetworkDidLoginNotification { get; }

        // extern NSString *const kJPFNetworkDidReceiveMessageNotification;
        /// <summary>
        /// 收到消息(非APNS)
        /// </summary> 
        [Field("kJPFNetworkDidReceiveMessageNotification")]
        NSString kJPFNetworkDidReceiveMessageNotification { get; }

        // extern NSString *const kJPFServiceErrorNotification;
        /// <summary>
        /// 错误提示
        /// </summary> 
        [Field("kJPFServiceErrorNotification")]
        NSString kJPFServiceErrorNotification { get; }
    }

    // @interface APService : NSObject
    [BaseType(typeof(NSObject))]
    interface APService
    {
        // +(void)setupWithOption:(NSDictionary *)launchingOption;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="launchingOption">Launching option.</param>
        [Static]
        [Export("setupWithOption:")]
        void SetupWithOption([NullAllowed] NSDictionary launchingOption);

        // +(void)registerForRemoteNotificationTypes:(NSUInteger)types categories:(NSSet *)categories;
        /// <summary>
        /// 注册APNS类型
        /// </summary>
        /// <param name="types">Types.</param>
        /// <param name="categories">Categories.</param>
        [Static] 
        [Export("registerForRemoteNotificationTypes:categories:")]
        void RegisterForRemoteNotificationTypes(nuint types, [NullAllowed] NSSet categories);

        // +(void)registerDeviceToken:(NSData *)deviceToken;
        /// <summary>
        /// 向服务器上报Device Token
        /// </summary>
        /// <param name="deviceToken">Device token.</param>
        [Static] 
        [Export("registerDeviceToken:")]
        void RegisterDeviceToken(NSData deviceToken);

        // +(void)handleRemoteNotification:(NSDictionary *)remoteInfo;
        /// <summary>
        /// 处理收到的APNS消息，向服务器上报收到APNS消息
        /// </summary>
        /// <param name="remoteInfo">Remote info.</param>
        [Static] 
        [Export("handleRemoteNotification:")]
        void HandleRemoteNotification(NSDictionary remoteInfo);

        // +(void)setTags:(NSSet *)tags alias:(NSString *)alias callbackSelector:(SEL)cbSelector target:(id)theTarget;
        /// <summary>
        ///  设置标签和(或)别名（若参数为nil，则忽略；若是空对象，则清空；）
        /// </summary> 
        /// <see cref="http://docs.jpush.cn/pages/viewpage.action?pageId=3309913"/> 
        [Static] 
        [Export("setTags:alias:callbackSelector:target:")]
        void SetTagsWithTarger([NullAllowed] NSSet tags, [NullAllowed] string alias, [NullAllowed]  Selector cbSelector, [NullAllowed] NSObject theTarget);

        // +(void)setTags:(NSSet *)tags alias:(NSString *)alias callbackSelector:(SEL)cbSelector object:(id)theTarget;
        /// <summary>
        ///  设置标签和(或)别名（若参数为nil，则忽略；若是空对象，则清空；）
        /// </summary> 
        /// <see cref="http://docs.jpush.cn/pages/viewpage.action?pageId=3309913"/> 
        [Static]
        [Export("setTags:alias:callbackSelector:object:")]
        void SetTagsWithObject([NullAllowed] NSSet tags, [NullAllowed] string alias, [NullAllowed] Selector cbSelector, [NullAllowed] NSObject theTarget);

        // +(void)setTags:(NSSet *)tags callbackSelector:(SEL)cbSelector object:(id)theTarget;
        /// <summary>
        ///  设置标签和(或)别名（若参数为nil，则忽略；若是空对象，则清空；）
        /// </summary> 
        /// <see cref="http://docs.jpush.cn/pages/viewpage.action?pageId=3309913"/> 
        [Static] 
        [Export("setTags:callbackSelector:object:")]
        void SetTagsWithTarget([NullAllowed] NSSet tags, [NullAllowed] Selector cbSelector, [NullAllowed] NSObject theTarget);

        // +(void)setAlias:(NSString *)alias callbackSelector:(SEL)cbSelector object:(id)theTarget;
        /// <summary>
        ///  设置标签和(或)别名（若参数为nil，则忽略；若是空对象，则清空；）
        /// </summary> 
        /// <see cref="http://docs.jpush.cn/pages/viewpage.action?pageId=3309913"/> 
        [Static]
        [Export("setAlias:callbackSelector:object:")]
        void SetAlias([NullAllowed] string alias, [NullAllowed] Selector cbSelector, [NullAllowed] NSObject theTarget);

        // +(NSSet *)filterValidTags:(NSSet *)tags;
        /// <summary>
        /// 用于过滤出正确可用的tags，如果总数量超出最大限制则返回最大数量的靠前的可用tags
        /// </summary>
        /// <returns>The valid tags.</returns>
        /// <param name="tags">Tags.</param>
        [Static]
        [Export("filterValidTags:")] 
        NSSet FilterValidTags(NSSet tags);

        #region 上报日志

        // +(void)startLogPageView:(NSString *)pageName;
        /// <summary>
        /// 记录页面停留时间功能。
        /// startLogPageView和stopLogPageView为自动计算停留时间
        /// </summary>
        /// <param name="pageName">页面名称</param>
        [Static] 
        [Export("startLogPageView:")]
        void StartLogPageView(string pageName);

        // +(void)stopLogPageView:(NSString *)pageName;
        /// <summary>
        /// 记录页面停留时间功能。
        /// startLogPageView和stopLogPageView为自动计算停留时间
        /// </summary>
        /// <param name="pageName">页面名称</param>
        [Static]
        [Export("stopLogPageView:")]
        void StopLogPageView(string pageName);

        // +(void)beginLogPageView:(NSString *)pageName duration:(int)seconds;
        /// <summary>
        /// 记录页面停留时间功能。
        /// beginLogPageView为手动自己输入停留时间
        /// </summary>
        /// <param name="pageName">页面名称</param>
        /// <param name="seconds">页面停留时间</param>
        [Static] 
        [Export("beginLogPageView:duration:")]
        void BeginLogPageView(string pageName, int seconds);

        // +(void)crashLogON;
        /// <summary>
        /// 开启Crash日志收集, 默认是关闭状态.
        /// </summary>
        [Static] 
        [Export("crashLogON")]
        void CrashLogON();

        // +(void)setLatitude:(double)latitude longitude:(double)longitude;
        /// <summary>
        /// 地理位置设置
        /// 为了更精确的统计用户地理位置，可以调用此方法传入经纬度信息
        /// 需要链接 CoreLocation.framework 并且 #import <CoreLocation/CoreLocation.h>
        /// </summary>
        /// <param name="latitude">纬度</param>
        /// <param name="longitude">经度/param>
        [Static] 
        [Export("setLatitude:longitude:")]
        void SetLatitude(double latitude, double longitude);

        // +(void)setLocation:(CLLocation *)location;
        /// <summary>
        /// 地理位置设置
        /// 为了更精确的统计用户地理位置，可以调用此方法传入经纬度信息
        /// 需要链接 CoreLocation.framework 并且 #import <CoreLocation/CoreLocation.h>
        /// </summary>
        /// <param name="location">直接传递CLLocation *型的地理信息</param> 
        [Static]
        [Export("setLocation:")]
        void SetLocation(CLLocation location);

        #endregion

        #region  本地通知

        // +(UILocalNotification *)setLocalNotification:(NSDate *)fireDate alertBody:(NSString *)alertBody badge:(int)badge alertAction:(NSString *)alertAction identifierKey:(NSString *)notificationKey userInfo:(NSDictionary *)userInfo soundName:(NSString *)soundName;
        /// <summary>
        /// 本地推送，最多支持64个
        /// </summary>
        /// <returns>The local notification.</returns>
        /// <param name="fireDate">本地推送触发的时间</param>
        /// <param name="alertBody">本地推送需要显示的内容</param>
        /// <param name="badge"> 角标的数字。如果不需要改变角标传-1</param>
        /// <param name="alertActionText">弹框的按钮显示的内容（IOS 8默认为"打开",其他默认为"启动"）</param>
        /// <param name="notificationKey">本地推送标示符</param>
        /// <param name="userInfo">自定义参数，可以用来标识推送和增加附加信息</param>
        /// <param name="soundName">自定义通知声音，设置为nil为默认声音</param>
        [Static] 
        [Export("setLocalNotification:alertBody:badge:alertAction:identifierKey:userInfo:soundName:")]
        UILocalNotification SetLocalNotification(NSDate fireDate, string alertBody, int badge, string alertActionText, string notificationKey, NSDictionary userInfo, [NullAllowed] string soundName);

        // +(UILocalNotification *)setLocalNotification:(NSDate *)fireDate alertBody:(NSString *)alertBody badge:(int)badge alertAction:(NSString *)alertAction identifierKey:(NSString *)notificationKey userInfo:(NSDictionary *)userInfo soundName:(NSString *)soundName region:(CLRegion *)region regionTriggersOnce:(BOOL)regionTriggersOnce category:(NSString *)category __attribute__((availability(ios, introduced=8.0)));
        /// <summary>
        /// 本地推送，最多支持64个,IOS8
        /// </summary>
        /// <returns>The local notification.</returns>
        /// <param name="fireDate">本地推送触发的时间</param>
        /// <param name="alertBody">本地推送需要显示的内容</param>
        /// <param name="badge"> 角标的数字。如果不需要改变角标传-1</param>
        /// <param name="alertActionText">弹框的按钮显示的内容（IOS 8默认为"打开",其他默认为"启动"）</param>
        /// <param name="notificationKey">本地推送标示符</param>
        /// <param name="userInfo">自定义参数，可以用来标识推送和增加附加信息</param>
        /// <param name="soundName">自定义通知声音，设置为nil为默认声音</param>
        /// <param name="region">自定义参数</param>
        /// <param name="regionTriggersOnce">自定义参数</param>
        /// <param name="category">自定义参数</param>
        [iOS(8, 0)]
        [Static] 
        [Export("setLocalNotification:alertBody:badge:alertAction:identifierKey:userInfo:soundName:region:regionTriggersOnce:category:")]
        UILocalNotification SetLocalNotification(NSDate fireDate, string alertBody, int badge, string alertActionText, string notificationKey, NSDictionary userInfo, string soundName, CLRegion region, bool regionTriggersOnce, string category);

        // +(void)showLocalNotificationAtFront:(UILocalNotification *)notification identifierKey:(NSString *)notificationKey;
        /// <summary>
        /// 本地推送在前台推送。默认App在前台运行时不会进行弹窗，在程序接收通知调用此接口可实现指定的推送弹窗。
        /// </summary>
        /// <param name="notification">本地推送对象</param>
        /// <param name="notificationKey">需要前台显示的本地推送通知的标示符</param>
        [Static] 
        [Export("showLocalNotificationAtFront:identifierKey:")]
        void ShowLocalNotificationAtFront(UILocalNotification notification, string notificationKey);

        // +(void)deleteLocalNotificationWithIdentifierKey:(NSString *)notificationKey;
        /// <summary>
        /// 删除本地推送
        /// </summary>
        /// <param name="notificationKey">本地推送标示符</param>
        [Static] 
        [Export("deleteLocalNotificationWithIdentifierKey:")]
        void DeleteLocalNotificationWithIdentifierKey(string notificationKey);

        // +(void)deleteLocalNotification:(UILocalNotification *)localNotification;
        /// <summary>
        ///删除本地推送
        /// </summary>
        /// <param name="localNotification">本地推送对象</param>
        [Static] 
        [Export("deleteLocalNotification:")]
        void DeleteLocalNotification(UILocalNotification localNotification);

        // +(NSArray *)findLocalNotificationWithIdentifier:(NSString *)notificationKey;
        /// <summary>
        /// 获取指定通知
        /// </summary>
        /// <returns>本地推送标示符</returns>
        /// <param name="notificationKey"> 本地推送对象数组,Count为0时表示没找到</param>
        [Static] 
        [Export("findLocalNotificationWithIdentifier:")] 
        UILocalNotification[] FindLocalNotificationWithIdentifier(string notificationKey);

        // +(void)clearAllLocalNotifications;
        /// <summary>
        /// 清除所有本地推送对象
        /// </summary>
        [Static] 
        [Export("clearAllLocalNotifications")]
        void ClearAllLocalNotifications();

        #endregion

        #region 设置Badge 既图标右上角的小圈圈

        // +(BOOL)setBadge:(NSInteger)value;
        /// <summary>
        ///  设置服务器脚标
        /// </summary>
        /// <remarks>本地仍须调用UIApplication:setApplicationIconBadgeNumber函数,来设置脚标</remarks>
        /// <returns><c>true</c>, if badge was set, <c>false</c> otherwise.</returns>
        /// <param name="value">设置JPush服务器的badge的值</param>
        [Static] 
        [Export("setBadge:")]
        bool SetBadge(nint value);

        // +(void)resetBadge;
        /// <summary>
        /// 清除服务器脚标
        /// </summary>
        /// <remarks>本地仍须调用UIApplication:setApplicationIconBadgeNumber函数,来设置脚标</remarks>
        [Static]
        [Export("resetBadge")]
        void ResetBadge();

        #endregion

        // +(NSString *)registrationID;
        [Static]
        [Export("registrationID")] 
        string RegistrationID { get; }

        #region 打印日志信息配置

        // +(void)setDebugMode;
        /// <summary>
        /// 获取更多的Log信息
        /// 开发过程中建议开启DebugMode
        /// <remarks>默认为不开启DebugLog,只显示基本的信息</remarks>
        /// </summary>
        [Static]
        [Export("setDebugMode")]
        void SetDebugMode();

        // +(void)setLogOFF;
        /// <summary>
        /// 关闭除了错误信息外的所有Log
        /// 发布时建议开启LogOFF用于节省性能开销
        /// <remarks>默认为不开启DebugLog,只显示基本的信息</remarks>
        /// </summary>
        [Static]
        [Export("setLogOFF")]
        void SetLogOFF();

        #endregion
    }
}
