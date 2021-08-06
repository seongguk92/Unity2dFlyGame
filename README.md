# Unity2dFlyGame
Unity 2D로 비행 게임 만들어보기

# github push 방법

▶ 기본
- git init #깃 초기화
- git remote add origin "git 주소" #원격 저장소 연결

▶ 대용량 파일
- git lfs install
- git lfs track "*.zip"
- git lfs track "*.psd"
- git lfs track "*.pdf"
- git lfs track "*.tgr"
- git lfs track "*.tiff"
- git lfs track "*.cubemap"

▶ git lfs 사용
- git add .gitattributes 
- git commit -m "Add gitattributes" 
- git push origin master

▶ 마무리
- git add .
- git commit -m "project copy"
- git push origin master
