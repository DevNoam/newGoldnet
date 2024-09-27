echo off
set dt=%date:~7,2%%date:~4,2%%date:~-4%%time:~0,2%%time:~3,2%%time:~6,2%
if exist "%1msgs\tgupdate\tgms.jar" (
	echo in if
	md %1msgs\tgupdate\old
	move %1tgms.jar %1msgs\tgupdate\old\
	cd %1msgs\tgupdate\old
	ren tgms.jar tgms.jar.%dt%
	cd %1
	move %1msgs\tgupdate\tgms.jar %1
)
