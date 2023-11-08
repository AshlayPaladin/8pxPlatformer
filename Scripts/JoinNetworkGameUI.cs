using Godot;
using System;

public partial class JoinNetworkGameUI : Control
{
	// Type Members
	bool _portValueSet;
	bool _ipAddressValueSet;
	bool _playerNameValueSet;
	int _port;

	// Object Members
	TextEdit _playerNameTextEdit;
	TextEdit _ipAddressTextEdit;
	TextEdit _portNumberTextEdit;
	Label _portWarningLabel;
	Button _connectButton;
	Button _cancelButton;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_playerNameTextEdit = GetNode<TextEdit>("PlayerNameControl/PlayerNameTextEdit");
		_ipAddressTextEdit = GetNode<TextEdit>("IPAddressControl/IPAddressTextEdit");
		_portNumberTextEdit = GetNode<TextEdit>("PortControl/PortTextEdit");
		_portWarningLabel = GetNode<Label>("PortWarningLabel");
		_connectButton = GetNode<Button>("ButtonControl/ConnectButton");
		_cancelButton = GetNode<Button>("ButtonControl/CancelButton");

		_portValueSet = true;
		_ipAddressValueSet = true;
		_playerNameValueSet = false;

		_port = 28281;
		
		GetTree().Root.ContentScaleFactor = 1.0f;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	private void _on_connect_button_pressed()
	{
		// Replace with function body.
	}

	private void _on_cancel_button_pressed()
	{
		// Return to Main Menu
		GetTree().ChangeSceneToFile("res://Scenes/Stages/DebugStart.tscn");
	}

	private void _on_player_name_text_edit_text_changed()
	{
		// Replace with function body.
		string _playerName = _playerNameTextEdit.Text;

		if(String.IsNullOrWhiteSpace(_playerName))
		{
			_playerNameValueSet = false;
		}
		else
		{
			_playerNameValueSet = true;

			char[] _nameChars = _playerName.ToCharArray();
			for(int i = _nameChars.Length - 1; i >= 0; i--)
			{
				int _charAscii = (int)_nameChars[i];

				if((_charAscii < 65) || (_charAscii >= 91 && _charAscii <= 96) || (_charAscii > 122))
				{
					_playerNameValueSet = false;
					break;
				}
			}
		}

		ValidateForm();
	}

	private void _on_port_text_edit_text_changed()
	{
		// Replace with function body.
		int _portParse;
		string _portText = _portNumberTextEdit.Text;

		bool parseSuccessful = int.TryParse(_portText, out _portParse);

		if(parseSuccessful)
		{
			// Set Port Number and Bool
			_portValueSet = true;
			_port = _portParse;
			_portWarningLabel.SetDeferred("visible", false);
		}
		else
		{
			// Enable Warning and Set Bool
			_portValueSet = false;
			_portWarningLabel.SetDeferred("visible", true);
		}

		ValidateForm();
	}

	private void _on_ip_address_text_edit_text_changed()
	{
		// Replace with function body.
		string _ipAddressValue = _ipAddressTextEdit.Text;

		if(String.IsNullOrWhiteSpace(_ipAddressValue))
		{
			_ipAddressValueSet = false;
		}
		else
		{
			_ipAddressValueSet = true;
		}

		ValidateForm();
	}

	private void ValidateForm()
	{
		if(_playerNameValueSet && _ipAddressValueSet && _portValueSet)
		{
			_connectButton.SetDeferred("disabled", false);
		}
		else
		{
			_connectButton.SetDeferred("disabled", true);
		}
	}
}
