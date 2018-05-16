--分享专区表
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bbs_area]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
    create table [dbo].[bbs_area]
    (
        area_uid                 uniqueidentifier not null,
        area_url                 nvarchar(256)   null,
        area_name                nvarchar(256)   null,
        begin_time               datetime        null,
        end_time                 datetime        null,
        post_count               int             null default 0,
        appraise_type            tinyint         null,
        is_allow_reply           tinyint         null,
        area_status              tinyint         null,
        remark                   nvarchar(2000)  null,
        sort_number              int             null,
        creator                  nvarchar(64)    null,
        creator_uid              uniqueidentifier null,
        create_time              datetime        null,
        last_modify_user         nvarchar(64)    null,
        last_modify_user_uid     uniqueidentifier null,
        last_modify_time         datetime        null,
            constraint PK_bbs_area PRIMARY KEY CLUSTERED
            ( area_uid )
    )
end
GO


--分享专区部门表
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bbs_area_dept]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
    create table [dbo].[bbs_area_dept]
    (
        id                       int             not null,
        area_uid                 uniqueidentifier null,
        dept_uid                 uniqueidentifier null,
            constraint PK_bbs_area_dept PRIMARY KEY CLUSTERED
            ( id )
    )
end
GO

--分享专区岗位表
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bbs_area_position]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
    create table [dbo].[bbs_area_position]
    (
        id                       int             not null,
        area_uid                 uniqueidentifier null,
        position_uid             uniqueidentifier null,
            constraint PK_bbs_area_position PRIMARY KEY CLUSTERED
            ( id )
    )
end
GO


--帖子表
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bbs_post]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
    create table [dbo].[bbs_post]
    (
        post_uid                 uniqueidentifier not null,
        area_uid                 uniqueidentifier null,
        title                    nvarchar(256)   null,
        content                  ntext           null,
        creator_uid              uniqueidentifier null,
        creator                  nvarchar(64)    null,
        create_time              datetime        null,
        visit_times              int             null default 0,
        reply_times              int             null default 0,
        like_times               int             null default 0,
        star_times               int             null default 0,
        recommend_times          int             null default 0,
        last_reply_time          datetime        null,
        last_update_time         datetime        null,
            constraint PK_bbs_post PRIMARY KEY CLUSTERED
            ( post_uid )
    )
end
GO



--帖子资源表
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bbs_post_resource]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
    create table [dbo].[bbs_post_resource]
    (
        resource_uid             uniqueidentifier not null,
        post_uid                 uniqueidentifier null,
        resource_type            tinyint         null,
        resource_url             nvarchar(256)   null,
            constraint PK_bbs_post_resource PRIMARY KEY CLUSTERED
            ( resource_uid )
    )
end
GO


-- 帖子推荐记录表
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bbs_recommend]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
    create table [dbo].[bbs_recommend]
    (
        recommend_uid            uniqueidentifier not null,
        user_uid                 uniqueidentifier null,
        post_uid                 uniqueidentifier null,
        create_time              datetime        null,
            constraint PK_bbs_recommend PRIMARY KEY CLUSTERED
            ( recommend_uid )
    )
end
GO




-- 帖子点赞记录表
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bbs_like]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
    create table [dbo].[bbs_like]
    (
        like_uid                 uniqueidentifier not null,
        user_uid                 uniqueidentifier null,
        post_uid                 uniqueidentifier null,
		create_time              datetime        null,
            constraint PK_bbs_like PRIMARY KEY CLUSTERED
            ( like_uid )
    )
end
GO



-- 帖子评星记录表
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bbs_star]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
    create table [dbo].[bbs_star]
    (
        star_uid                 uniqueidentifier not null,
        user_uid                 uniqueidentifier null,
        post_uid                 uniqueidentifier null,
        star_level               tinyint         null,
            constraint PK_bbs_star PRIMARY KEY CLUSTERED
            ( star_uid )
    )
end
GO

-- 帖子回帖表
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bbs_reply]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
    create table [dbo].[bbs_reply]
    (
        reply_uid                uniqueidentifier not null,
        post_uid                 uniqueidentifier null,
        content                  ntext           null,
        creator_uid              uniqueidentifier null,
        creator                  nvarchar(64)    null,
        create_time              datetime        null,
            constraint PK_bbs_reply PRIMARY KEY CLUSTERED
            ( reply_uid )
    )
end
GO

-- 二级回帖表
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bbs_subreply]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
    create table [dbo].[bbs_subreply]
    (
        subreply_uid             uniqueidentifier not null,
        reply_uid                uniqueidentifier null,
        post_uid                 uniqueidentifier null,
        content                  ntext           null,
        creator_uid              uniqueidentifier null,
        creator                  nvarchar(64)    null,
        create_time              datetime        null,
            constraint PK_bbs_subreply PRIMARY KEY CLUSTERED
            ( subreply_uid )
    )
end
GO





  

  




