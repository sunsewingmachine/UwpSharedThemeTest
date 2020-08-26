
Follow the steps below to implement Theme in any project/page:
---------------------------------------------------------------

        // Add reference to this 'Shared_Themes' Class library.
        // Add the following in the code behind (.cs)file of the xaml page, which requires the Theme

        public ThemeColor MyTheme { get; set; } = new ThemeColor();
                
        public MainPage()
        {
            ThemeController.RefreshTheme(MyTheme);
            this.InitializeComponent();
        }


                
        // Create a menu in xaml page x:Name="ShowThemeDialog", like below

        <AppBarButton x:Name="ShowThemeDialog" 
                          Label="Change Theme" 
                          Icon="Highlight"
                          Foreground="Black" 
                          Click="ShowThemeDialog_OnClick" />
        
        private void BtnShowThemeDialog_OnClick(object sender, RoutedEventArgs e)
        {
            ThemeController.ShowThemeDialog(MyTheme);
        }

        RequestedTheme="{x:Bind MyTheme.RequestedTheme, Mode=OneWay}"
        Background="{x:Bind MyTheme.Brush1, Mode=OneWay}"
        Background="{x:Bind MyTheme.Brush2, Mode=OneWay}"
        Background="{x:Bind MyTheme.Brush1Text, Mode=OneWay}"
        Background="{x:Bind MyTheme.Brush2Text, Mode=OneWay}"         
        Background="{x:Bind MyTheme.BrushBlack, Mode=OneWay}"
        Background="{x:Bind MyTheme.BrushNearBlack, Mode=OneWay}"         

         
        <Grid x:Name="GrdBase">
            <Image HorizontalAlignment="Stretch"
                VerticalAlignment="Stretch"
                Opacity="0.2"
                Stretch="Fill"
                Source="{x:Bind MyTheme.BackImage, Mode=OneWay}" />

        </Grid>